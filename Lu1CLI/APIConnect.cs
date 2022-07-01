using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace mtaAVCLI
{
    public class DataRequest
    {
        public string typeHash { get; set; }
        public string TimeVersion { get; set; }
        public DataRequest() { }
        public DataRequest(string typeHash)
        {
            DateTime date = DateTime.UtcNow.Date;
            this.typeHash = typeHash;
            this.TimeVersion = date.ToString("dd-MM-yyyy");
        }
    }
    public class APIConnect
    {
        string configFile = "Config.txt";
        string error = "Không kết nối tới máy chủ! Kiểm tra lại kết nối!";
        public string Download_FileHash(string type)
        {
            string uri = "";
            if (File.Exists(configFile))
            {
                uri = File.ReadAllLines(configFile)[0];
            }
            else
            {
                return "Không có File Config API?";
            }

            string saveFile = string.Format("{0}\\Temp\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = saveFile + type + "_" + DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + ".txt";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                try
                {
                    var content = new DataRequest(type);
                    var json = JsonConvert.SerializeObject(content);
                    Console.WriteLine(json.ToString());
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("CheckUpdate", data);
                    response.Wait();
                    Console.WriteLine(response.Result.IsSuccessStatusCode);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var contentStream = response.Result.Content.ReadAsByteArrayAsync().Result;
                        File.WriteAllBytes(path, contentStream);
                        return path;
                    }
                }
                catch 
                {
                    return error;
                }
            }
            return error;
        }
    } 
}

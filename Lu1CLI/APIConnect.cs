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
        public DataRequest(string typeHash, string TimeVersion)
        {
            this.typeHash = typeHash;
            this.TimeVersion = TimeVersion;
        }
    }
    public class APIConnect
    {
        string configFile = "Config.txt";
        string version = "version.txt";
        string error = "Không kết nối tới máy chủ! Kiểm tra lại kết nối!";
        public string Download_FileHash(string type)
        {
            string uri = "";
            string verDate = "";
            if (File.Exists(configFile))
            {
                uri = File.ReadAllLines(configFile)[0];
            }
            else
            {
                return @"Không có File Config API? Nhập địa chỉ dạng http://127.0.0.0.:9090/";
            }

            if (File.Exists(version))
            {
                verDate = File.ReadAllLines(version)[0];
            }
            else
            {
                return "Không có File Version! Cần tạo file version dạng dd-MM-yyyy";
            }

            string saveFile = string.Format("{0}\\Temp\\", AppDomain.CurrentDomain.BaseDirectory);
            string dateNow = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string path = saveFile + type + "_" + dateNow + ".txt";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                try
                {
                    var content = new DataRequest(type, verDate);
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

                        // làm sạch file và ghi date mới nhất
                        File.WriteAllText(version, string.Empty);
                        File.WriteAllText(version, dateNow);
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

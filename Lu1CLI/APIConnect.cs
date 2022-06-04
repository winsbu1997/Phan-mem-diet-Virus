using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace mtaAVCLI
{
    public static class APIConnect
    {
        static readonly string configFile = "Config.txt";
        static readonly string verFile = "version.txt";
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
        public static string Download_FileHash(string type)
        {
            string uri = "";
            string ver = "";
            if (File.Exists(configFile))
            {
                uri = File.ReadAllLines(configFile)[0];
            }
            else
            {
                return "Không có File Config API?";
            }

            if (File.Exists(verFile))
            {
                ver = File.ReadAllLines(verFile)[0];
            }
            else
            {
                return "Không có File Config versionn?";
            }

            string saveFile = string.Format("{0}\\Temp\\", AppDomain.CurrentDomain.BaseDirectory);
            string path = type + "_" + DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + ".txt";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                try
                {
                    var data = new { typeHash = type, version = ver};
                    var response = client.PostAsync("CheckUpdate", data.AsJson());
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var contentStream = response.Result.Content.ReadAsByteArrayAsync().Result;
                        File.WriteAllBytes(path, contentStream);
                        return path;
                    }
                }
                catch { }
                return null;
            }
        }
    } 
}

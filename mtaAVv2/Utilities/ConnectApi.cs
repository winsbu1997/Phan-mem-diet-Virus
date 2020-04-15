using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ladin.mtaAV.Model;
using System.Globalization;

namespace Ladin.mtaAV.Utilities
{
    public class ConnectApi
    {
        public static string path = "http://192.168.1.106:5001/";
        public List<ConnectApi> resultEngine = new List<ConnectApi>();
        //public static string path = "http://" + Provider.url + ":" + Provider.port + "/";
        public string Engine { get; set; }
        public string Is_Malware { get; set; }
        public string Score { get; set; }
        public string Message { get; set; }
        public List<ConnectApi> GetResult()
        {
            return resultEngine;
        }
        public ConnectApi() { }
        public ConnectApi(string Engine, string Is_Malware, string Score, string Message)
        {
            this.Engine = Engine;
            this.Is_Malware = Is_Malware;
            this.Score = Score;
            this.Message = Message;
        }
        public ConnectApi AssignEngine(string engineer, string dict)
        {
            ConnectApi tmp = new ConnectApi();
            var dict4 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dict);
            tmp.Is_Malware = dict4["is_malware"].ToString() == "1" ? "Có" : "Không";
            tmp.Message = dict4["msg"].ToString();
            tmp.Score = dict4["score"].ToString();
            tmp.Engine = engineer;
            return tmp;
        }
        public List<QUARANTINES> Upload_MultiFiles<T>(string endpointUrl, string[] files)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(30);
                client.BaseAddress = new Uri(path);
                using (var formData = new MultipartFormDataContent())
                {
                    foreach (string filePath in files)
                    {
                        formData.Add(new ByteArrayContent(File.ReadAllBytes(filePath)), "files[]", Path.GetFileName(filePath));
                    }
                    var response = client.PostAsync(endpointUrl, formData);
                    response.Wait();
                    List<QUARANTINES> lst = new List<QUARANTINES>();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var json = response.Result.Content.ReadAsStringAsync().Result;
                        File.WriteAllText(@"~/log/" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture) + ".json", json);
                        var dict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
                        string dyn = dict["status"].ToString();
                        if (dyn == "success")
                        {
                            dynamic val = dict["status_msg"].ToString();
                            var dict2 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(val);
                            foreach (KeyValuePair<string, dynamic> item in dict2)
                            {
                                //Console.WriteLine(item.Key);
                                string msg_ID = item.Value.ToString();
                                var dict3 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(msg_ID);
                                QUARANTINES tmp = new QUARANTINES();
                                tmp.FILENAME = dict3["filename"].ToString();
                                tmp.VIRUS = dict3["is_malware"].ToString();
                                tmp.TYPE_SCAN = "Động";
                                tmp.CREATE_DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                lst.Add(tmp);
                                resultEngine.Add(AssignEngine("cuckoo", dict3["cuckoo"].ToString()));
                                resultEngine.Add(AssignEngine("HAN", dict3["HAN"].ToString()));
                                resultEngine.Add(AssignEngine("virustotal", dict3["virustotal"].ToString()));
                            }
                            return lst;
                        }
                    }
                    return null;
                }
            }
        }

        //public static T Upload_File<T>(string endpointUrl, string file)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(path);
        //        using (var formData = new MultipartFormDataContent())
        //        {
        //            formData.Add(new ByteArrayContent(File.ReadAllBytes(file)), "file", Path.GetFileName(file));
        //            var response = client.PostAsync(endpointUrl, formData);
        //            response.Wait();
        //            //if (response.Result.IsSuccessStatusCode)
        //            var obj = response.Result.Content.ReadAsStringAsync().Result;
        //            var data = JsonConvert.DeserializeObject<T>(obj);
        //            return data;
        //        }
        //    }
        //}
    }
}
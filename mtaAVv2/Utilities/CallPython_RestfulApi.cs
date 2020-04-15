using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ladin.mtaAV.Utilities
{
    class CallPython_RestfulApi 
    {
        public static T TestCallApi<T>(string uirWebAPI, string file, out string exceptionMessage)
        {
            exceptionMessage = string.Empty;
            string webResponse = string.Empty;
            try
            {
                Uri uri = new Uri(uirWebAPI);
                WebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    // Build employee test JSON objec
                    dynamic employee = new JObject();
                    employee.file = File.ReadAllBytes(file);
                    streamWriter.Write(employee.ToString());
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    webResponse = streamReader.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<T>(webResponse);
                    return data;
                }
            }
            catch (Exception ex)
            {
                exceptionMessage = $"An error occurred. {ex.Message}";
            }
            return JsonConvert.DeserializeObject<T>(null);
        }
    }
}

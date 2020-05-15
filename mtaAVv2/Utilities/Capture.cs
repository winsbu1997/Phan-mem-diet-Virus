using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladin.mtaAV.Utilities
{
    public class Capture
    {
        public string filename { get; set; }
        public string file_size { get; set; }
        public string file_extension { get; set; }
        public string file_path { get; set; }
        public string hash { get; set; }
        public string md5 { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public string date_sent { get; set; }
        public string time_sent { get; set; }
        public string date_received { get; set; }
        public string time_received { get; set; }
        public string collection_date { get; set; }
        public string collection_type { get; set; }
        public string source_ip { get; set; }
        public string destination_ip { get; set; }
        public string source_url { get; set; }
        public string destination_url { get; set; }
        public string hostname { get; set; }
        public string protocol { get; set; }
        public string source_email { get; set; }
        public string destination_email { get; set; }
        public string source_country { get; set; }
        public string destination_country { get; set; }
        public string malware_type { get; set; }
        public string source_dns { get; set; }
        public string destination_dns { get; set; }
        public string entropy { get; set; }
        public string description { get; set; }
        public int detected_by { get; set; }
        public double warning_level { get; set; }

        public Capture() { }

        public Capture(string filename = null, string file_size = null, string source_ip = null, string destination_ip = null, string file_extension = null, string file_path= null, string hash= null, string md5= null, string date_created= null, string date_modified= null, string date_sent= null, string time_sent= null, string date_received= null, string time_received= null, string collection_date= null, string collection_type= null, string source_url= null, string destination_url= null, string hostname= null, string protocol= null, string source_email= null, string destination_email= null, string source_country= null, string destination_country= null, string malware_type= null, string source_dns= null, string destination_dns= null, string entropy= null, string description= null, int detected_by = 0, double warning_level = 0)
        {
            this.filename = filename;
            this.file_size = file_size;
            this.file_extension = file_extension;
            this.file_path = file_path;
            this.hash = hash;
            this.md5 = md5;
            this.date_created = date_created;
            this.date_modified = date_modified;
            this.date_sent = date_sent;
            this.time_sent = time_sent;
            this.date_received = date_received;
            this.time_received = time_received;
            this.collection_date = collection_date;
            this.collection_type = collection_type;
            this.source_ip = source_ip;
            this.destination_ip = destination_ip;
            this.source_url = source_url;
            this.destination_url = destination_url;
            this.hostname = hostname;
            this.protocol = protocol;
            this.source_email = source_email;
            this.destination_email = destination_email;
            this.source_country = source_country;
            this.destination_country = destination_country;
            this.malware_type = malware_type;
            this.source_dns = source_dns;
            this.destination_dns = destination_dns;
            this.entropy = entropy;
            this.description = description;
            this.detected_by = detected_by;
            this.warning_level = warning_level;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ladin.mtaAV.Model
{
    [Table(Name = "QUARANTINES")]
    public partial class QUARANTINES
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "FILENAME", DbType = "STRING")]
        public string FILENAME { get; set; }

        [Column(Name = "VIRUS", DbType = "STRING")]
        public string VIRUS { get; set; }

        [Column(Name = "TYPE_SCAN", DbType = "STRING")]
        public string TYPE_SCAN { get; set; }

        [Column(Name = "CREATE_DATE", DbType = "STRING")]
        public string CREATE_DATE { get; set; }

        public QUARANTINES() { }
        public QUARANTINES(string FILENAME, string VIRUS, string TYPE_SCAN, string CREATE_DATE)
        {
            this.FILENAME = FILENAME;
            this.VIRUS = VIRUS;
            this.TYPE_SCAN = TYPE_SCAN;
            this.CREATE_DATE = CREATE_DATE;
        }
    }
}

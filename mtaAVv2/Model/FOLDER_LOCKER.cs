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
    [Table(Name = "FOLDER_LOCKER")]
    public partial class FOLDER_LOCKER
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "FILENAME", DbType = "STRING")]
        public string FILENAME { get; set; }

        [Column(Name = "KEY", DbType = "STRING")]
        public string KEY { get; set; }

        public FOLDER_LOCKER() { }
        public FOLDER_LOCKER(string FILENAME, string KEY)
        {
            this.FILENAME = FILENAME;
            this.KEY = KEY;
        }

    }
}

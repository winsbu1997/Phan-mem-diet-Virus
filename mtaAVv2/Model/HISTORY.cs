using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace Ladin.mtaAV.Model
{
    [Table(Name = "HISTORY")]
    public partial class HISTORY
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "COUNT", DbType = "INT")]
        public int COUNT { get; set; }

        [Column(Name = "CREATE_DATE", DbType = "DATETIME")]
        public DateTime? CREATE_DATE { get; set; }

        [Column(Name = "TYPE_SCAN", DbType = "STRING")]
        public string TYPE_SCAN { get; set; }

        public HISTORY() { }
        public HISTORY(int COUNT, DateTime? CREATE_DATE, string TYPE_SCAN)
        {
            this.COUNT = COUNT;
            this.CREATE_DATE = CREATE_DATE;
            this.TYPE_SCAN = TYPE_SCAN;
        }
    }
}

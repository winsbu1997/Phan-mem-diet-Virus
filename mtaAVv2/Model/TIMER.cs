﻿using System;
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
    [Table(Name = "TIMER")]
    public partial class TIMER
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "FILENAME", DbType = "STRING")]
        public string FILENAME { get; set; }

        public TIMER() { }
        public TIMER(string FILENAME)
        {
            this.FILENAME = FILENAME;
        }
    }
}

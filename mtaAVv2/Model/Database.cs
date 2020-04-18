using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladin.mtaAV.Model
{
    public partial class Database : DbContext
    {
        public Database()
        : base("db") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (File.Exists("MtaAv.db")) return;
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Database>(modelBuilder);
            System.Data.Entity.Database.SetInitializer(sqliteConnectionInitializer);
        }

        public DbSet<FOLDER_LOCKER> FOLDER_LOCKER { get; set; }
        public DbSet<HISTORY> HISTORY { get; set; }
        public DbSet<QUARANTINES> QUARANTINE { get; set; }
        public DbSet<FOLDER_MONITOR> FOLDER_MONITOR { get; set; }
        public DbSet<EXCLUSION> EXCLUSION { get; set; }
        public DbSet<TIMER> TIMER { get; set; }
    }
}

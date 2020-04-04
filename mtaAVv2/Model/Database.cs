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
        public static string runningPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = string.Format("{0}Model\\mtaAV.db", Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
        public Database() : base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = databasePath, ForeignKeys = false }.ConnectionString
            }, true)
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FOLDER_LOCKER> FOLDER_LOCKER { get; set; }
        public DbSet<HISTORY> HISTORY { get; set; }
        public DbSet<QUARANTINES> QUARANTINE { get; set; }
        public DbSet<FOLDER_MONITOR> FOLDER_MONITOR { get; set; }
        public DbSet<EXCLUSION> EXCLUSION { get; set; }
        public DbSet<TIMER> TIMER { get; set; }
    }
}

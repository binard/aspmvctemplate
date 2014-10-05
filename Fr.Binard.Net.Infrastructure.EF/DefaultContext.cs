using Fr.Binard.Net.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public class DefaultContext : DbContext
    {
        public DefaultContext()
            : this(InfraConfiguration.DB_NAME)
        {
        }

        public DefaultContext(string dbName)
            : base(dbName)
        {
            Database.SetInitializer<DefaultContext>(null);
        }

        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new TestMapping());
        }

    }
}

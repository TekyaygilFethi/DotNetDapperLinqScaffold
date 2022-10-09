using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Database.DbContexts
{
    public partial class DapperLinqScaffoldDbContext:DbContext
    {
        public DapperLinqScaffoldDbContext(DbContextOptions options) : base(options) { }

        public DapperLinqScaffoldDbContext()
          : base() { }

        public DapperLinqScaffoldDbContext(string connectionString)
          : base(NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureHeroEntities(modelBuilder);
            ConfigureRaceEntities(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.EnableSensitiveDataLogging();
        }
    }
}

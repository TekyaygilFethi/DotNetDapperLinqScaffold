using DapperLinqScaffold.Data.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Database.DbContexts
{
    public partial class DapperLinqScaffoldDbContext : DbContext
    {
        public DbSet<Race> Races { get; set; }

        private void ConfigureRaceEntities(ModelBuilder builder)
        {
            builder.Entity<Race>()
               .HasIndex(u => u.Name)
               .IsUnique();

            builder.SeedRaceData();
        }
    }
}

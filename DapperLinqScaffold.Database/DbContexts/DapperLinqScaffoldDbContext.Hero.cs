using DapperLinqScaffold.Data.POCO;
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
        public DbSet<Hero> Heroes { get; set; }

        private void ConfigureHeroEntities(ModelBuilder builder)
        {
            builder.SeedHeroData();
        }

    }
}

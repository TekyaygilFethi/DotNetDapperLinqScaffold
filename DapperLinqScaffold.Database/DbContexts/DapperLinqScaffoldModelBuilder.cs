using DapperLinqScaffold.Data.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Database.DbContexts
{
    public static class DapperLinqScaffoldModelBuilder
    {
        public static void SeedRaceData(this ModelBuilder builder)
        {
            Race r1 = new Race
            {
                Id = 1,
                Name = "Elf"
            };

            Race r2 = new Race
            {
                Id = 2,
                Name = "Human"
            };

            Race r3 = new Race
            {
                Id = 3,
                Name = "Jedi"
            };

            Race r4 = new Race
            {
                Id = 4,
                Name = "Maiar"
            };

            Race r5 = new Race
            {
                Id = 5,
                Name = "Sith"
            };

            builder.Entity<Race>().HasData(
               r1, r2, r3, r4, r5);

        }

        public static void SeedHeroData(this ModelBuilder builder)
        {
            Hero h1 = new Hero
            {
                Id = 1,
                Name = "Legolas",
                Power = 80,
                RaceId = 1
            };

            Hero h2 = new Hero
            {
                Id = 2,
                Name = "Elrond",
                Power = 85,
                RaceId = 1
            };

            Hero h3 = new Hero
            {
                Id = 3,
                Name = "Solid Snake",
                Power = 75,
                RaceId = 2
            };

            Hero h4 = new Hero
            {
                Id = 4,
                Name = "Cloud",
                Power = 70,
                RaceId = 2
            };

            Hero h5 = new Hero
            {
                Id = 5,
                Name = "Zack",
                Power = 80,
                RaceId = 2
            };

            Hero h6 = new Hero
            {
                Id = 6,
                Name = "Obi-Wan Kenobi",
                Power = 90,
                RaceId = 3
            };

            Hero h7 = new Hero
            {
                Id = 7,
                Name = "Anakin Skywalker",
                Power = 95,
                RaceId = 3
            };

            Hero h8 = new Hero
            {
                Id = 8,
                Name = "Gandalf",
                Power = 95,
                RaceId = 4
            };

            Hero h9 = new Hero
            {
                Id = 9,
                Name = "Count Dooku",
                Power = 100,
                RaceId = 5
            };

            Hero h10 = new Hero
            {
                Id = 10,
                Name = "Darth Maul",
                Power = 85,
                RaceId = 5
            };

            builder.Entity<Hero>().HasData(
               h1, h2, h3, h4, h5, h6, h7, h8, h9, h10);
        }
    }
}

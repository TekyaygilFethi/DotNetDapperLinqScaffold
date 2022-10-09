using DapperLinqScaffold.Data.POCO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Data.POCO
{
    [Table("HeroTable")]
    public class Hero:POCOEntity
    {
        public string Name { get; set; }

        public int RaceId { get; set; }

        public int Power { get; set; }
    }
}

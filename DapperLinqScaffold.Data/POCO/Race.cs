using DapperLinqScaffold.Data.POCO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Data.POCO
{
    [Table("RaceTable")]
    public class Race:POCOEntity
    {
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Data.POCO.Base
{
    public class POCOEntity : IPrimaryKey<int>
    {
        public int Id { get; set; }
    }
}

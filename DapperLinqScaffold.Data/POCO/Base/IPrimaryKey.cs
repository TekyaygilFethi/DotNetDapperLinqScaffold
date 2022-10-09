using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Data.POCO.Base
{
    public interface IPrimaryKey<T>
    {
        public T Id { get; set; }
    }
}

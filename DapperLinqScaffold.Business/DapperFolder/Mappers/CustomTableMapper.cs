using Dapper.Extensions.Linq.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.DapperFolder.Mappers
{
    public class CustomTableMapper<T> : AutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            base.Table(tableName + "Table");
        }
    }
}

using Dapper.Extensions.Linq.Predicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.RepositoryFolder
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(PredicateGroup pg = null);

        T GetSingle(PredicateGroup pg);

        IEnumerable<T> GetList(PredicateGroup pg);

        void Insert(T item);

        void Insert(IEnumerable<T> items);

        void Update(T item);

        void Update(IEnumerable<T> items);

        void Delete(T item);

        void Delete(IEnumerable<T> items);
    }
}

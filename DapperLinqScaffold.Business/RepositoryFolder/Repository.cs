using Dapper.Extensions.Linq.Extensions;
using Dapper.Extensions.Linq.Predicates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.RepositoryFolder
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDbConnection _conn;
        public Repository(IDbConnection connection)
        {
            _conn = connection;
        }

        public IEnumerable<T> GetAll(PredicateGroup pg = null)
        {
            _conn.Open();
            IEnumerable<T> response = null;

            response = _conn.GetList<T>(pg);

            _conn.Close();
            return response;
        }

        public T GetSingle(PredicateGroup pg)
        {
            var response = GetAll(pg).FirstOrDefault();

            return response;
        }


        public IEnumerable<T> GetList(PredicateGroup pg)
        {
            _conn.Open();
            var response = _conn.GetList<T>(pg);


            _conn.Close();
            return response;
        }


        public void Insert(T item)
        {
            _conn.Open();
            _conn.Insert(item);
            _conn.Close();
        }

        public void Insert(IEnumerable<T> items)
        {
            _conn.Open();
            _conn.Insert(items);
            _conn.Close();
        }

        public void Update(T item)
        {
            _conn.Open();
            _conn.Update(item);
            _conn.Close();
        }

        public void Update(IEnumerable<T> items)
        {
            _conn.Open();
            foreach (var item in items)
            {
                _conn.Update(item);
            }
            _conn.Close();
        }



        public void Delete(T item)
        {
            _conn.Open();
            _conn.Delete(item);
            _conn.Close();
        }

        public void Delete(IEnumerable<T> items)
        {
            _conn.Open();
            _conn.Delete(items);
            _conn.Close();
        }
    }
}

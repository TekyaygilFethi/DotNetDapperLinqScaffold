using DapperLinqScaffold.Business.RepositoryFolder;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.UnitOfWorkFolder
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            IDbConnection _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQLConnString"));

            return (IRepository<TEntity>)Activator.CreateInstance(typeof(Repository<TEntity>), new object[] { _dbConnection });
        }
    }
}

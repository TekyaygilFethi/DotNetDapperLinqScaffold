using DapperLinqScaffold.Business.UnitOfWorkFolder;
using Microsoft.AspNetCore.Mvc;

namespace DapperLinqScaffold.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public IConfiguration _configuration;

        public BaseController( IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected TService GetService<TService>() where TService : class
        {
            return (TService)Activator.CreateInstance(typeof(TService), new object[] { _uow });
        }
    }
}

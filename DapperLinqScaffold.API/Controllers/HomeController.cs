using DapperLinqScaffold.API.Controllers.Base;
using DapperLinqScaffold.Business.Services.HeroServiceFolder;
using DapperLinqScaffold.Business.UnitOfWorkFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperLinqScaffold.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        IHeroService _heroService;
        public HomeController(IUnitOfWork uow) : base(uow)
        {
            _heroService = base.GetService<HeroService>();
        }

        [HttpGet, Route("GetAllHeroes")]
        public IActionResult GetAllHeroes()
        {
            var heroes = _heroService.GetAllHeroes();

            return Ok(heroes);
        }


        [HttpGet, Route("GetAllHeroesByRace")]
        public IActionResult GetAllHeroesByRace([FromQuery]string race)
        {
            var heroes = _heroService.GetHeroesByRace(race);

            return Ok(heroes);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.Services.HeroServiceFolder
{
    public interface IHeroService
    {
        object GetAllHeroes();

        object GetHeroesByRace(string race);
    }
}

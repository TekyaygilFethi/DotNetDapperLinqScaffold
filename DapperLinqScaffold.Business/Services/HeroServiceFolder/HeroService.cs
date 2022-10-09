using Dapper.Extensions.Linq.Core.Enums;
using Dapper.Extensions.Linq.Core.Predicates;
using Dapper.Extensions.Linq.Predicates;
using DapperLinqScaffold.Business.RepositoryFolder;
using DapperLinqScaffold.Business.UnitOfWorkFolder;
using DapperLinqScaffold.Data.POCO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLinqScaffold.Business.Services.HeroServiceFolder
{
    public class HeroService:IHeroService
    {
        readonly IRepository<Hero> _heroRepository;
        readonly IRepository<Race> _raceRepository;

        public HeroService(IUnitOfWork uow)
        {
            _heroRepository = uow.GetRepository<Hero>();
            _raceRepository = uow.GetRepository<Race>();
        }


        public object GetAllHeroes()
        {
            return _heroRepository.GetAll().Join(_raceRepository.GetAll(),
                hero => hero.RaceId,
                race =>race.Id,
                (hero, race) => new { Hero = hero, Race = race });
        }



        public object GetHeroesByRace(string race)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<Race>(h => h.Name, Operator.Eq, race));

            var raceId = _raceRepository.GetSingle(pg).Id;
            pg.Predicates.Clear();


            pg.Predicates.Add(Predicates.Field<Hero>(h => h.RaceId, Operator.Eq, raceId));

            return _heroRepository.GetList(pg).Join(_raceRepository.GetAll(),
                hero => hero.RaceId,
                race => race.Id,
                (hero, race) => new { Hero = hero, Race = race }).OrderByDescending(o=>o.Hero.Power).ToList();
        }

    }
}

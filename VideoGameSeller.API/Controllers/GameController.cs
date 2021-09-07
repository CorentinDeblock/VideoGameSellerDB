using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Form;
using Models.Form.RelationForm;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        IRepository<GameModel, GameForm> Repository;

        public GameController(IRepository<GameModel, GameForm> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IEnumerable<GameModel> Get() => Repository.GetAll();

        [HttpGet("{id}")]
        public GameModel Get(int id) => Repository.Get(id);

        [HttpPost]
        public GameModel Insert(GameForm form) => Repository.Insert(form);

        [HttpPost("Platform")] 
        public PlatformModel Insert(PlatformGameForm form) => Repository.GetRepo<PlatformModel, PlatformGameForm>("PlatformGame").Insert(form);
    }
}

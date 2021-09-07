using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Form;
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
    public class PlatformController : Controller
    {
        IRepository<PlatformModel, PlatformForm> Repository;

        public PlatformController(IRepository<PlatformModel, PlatformForm> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IEnumerable<PlatformModel> Get() => Repository.GetAll();

        [HttpGet("{Id}")]
        public PlatformModel Get(int id) => Repository.Get(id);

        [HttpPost]
        public PlatformModel Insert(PlatformForm form) => Repository.Insert(form);
    }
}

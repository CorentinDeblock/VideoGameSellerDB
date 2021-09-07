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
    public class CompanyController : Controller
    {
        IRepository<CompanyModel, CompanyForm> Repository;

        public CompanyController(IRepository<CompanyModel, CompanyForm> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IEnumerable<CompanyModel> Get() => Repository.GetAll();

        [HttpPost]
        public CompanyModel Insert(CompanyForm form) => Repository.Insert(form);
    }
}

using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Form;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repository;
using VideoGameSeller.API.Services;
using VideoGameSeller.Tools;

namespace VideoGameSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IRepository<User,UserForm> Repo;

        public UserController(IRepository<User,UserForm> repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Repo.GetAll();
        }

        [HttpPost]
        public IActionResult Insert(UserForm form)
        {
            Repo.Insert(form);
            return Ok();
        }

        [HttpPut]
        public User Update(int id,string username,string email)
        {
            Repo.Update(id, new UserForm
            {
                Username = username,
                Email = email
            });
            return Repo.Get(id);
        }
        
        [HttpDelete]
        public bool Delete(int id)
        {
            return Repo.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;

namespace VideoGameSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        CRUD<User> CRUD;

        public UserController(CRUD<User> cRUD)
        {
            CRUD = cRUD;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return CRUD.Read((DbDataReader reader) =>
            {
                return new User { Email = reader["Email"].ToString(), Username = reader["Username"].ToString() };
            });
        }
    }
}

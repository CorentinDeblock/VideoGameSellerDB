using Models;
using Models.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Services;
using VideoGameSeller.Tools;

namespace VideoGameSeller.API.Repository
{
    public class UserRepository : Repository, IRepository<User,UserForm>
    {
        public UserRepository(Connection connection) : base(connection, "User")
        {
        }

        public bool Delete(int id)
        {
            return CRUD.Delete(new {
                WHERE = new {
                    id = id
                }
            });
        }

        public User Get(int id)
        {
            return CRUD.Read((dbReader) => new User
            {
                Email = (string)dbReader["Email"],
                Password = (byte[])dbReader["Password"],
                Username = (string)dbReader["Username"],
                Salt = (string)dbReader["Salt"]
            }, new QueryOption{
                Where = { 
                    { "Id", id} 
                }
            }).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return CRUD.Read((dbReader) => new User
            {
                Email = (string)dbReader["Email"],
                Password = (byte[])dbReader["Password"],
                Username = (string)dbReader["Username"],
                Salt = (string)dbReader["Salt"]
            });
        }

        public void Insert(UserForm form)
        {
            User user = new User
            {
                Email = form.Email,
                Username = form.Username,
                Salt = Guid.NewGuid().ToString()
            };
            user.Password = PasswordHasher.Hashing(user, form.Password, u => u.Salt);

            CRUD.Create(user);
        }

        public void Update(int id,UserForm model)
        {
            CRUD.Update(new
            {
                Username = model.Username,
                Email = model.Email,
                WHERE = new
                {
                    Id = id
                }
            });
        }
    }
}

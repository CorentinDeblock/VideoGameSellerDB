using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repositories.Bases;
using VideoGameSeller.API.Repositories.Mappers;

namespace VideoGameSeller.API.Repositories
{
    public class UserRepository : Repository<UserModel, UserForm>
    {

        public UserRepository(Connection connection) : base(connection)
        {
            isInsertAProcedure = true;
        }

        protected override Mapper<UserModel> Mapper => new UserMapper();
    }
}

using Models;
using Models.Enum;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class UserMapper : Mapper<UserModel>
    {
        public UserMapper(IEnumerable<string> Prefix = null) : base(Prefix)
        {
        }

        public override UserModel MapReaderToModel(DataContext context)
        {
            return new UserModel
            {
                Id = (int)context["Id"],
                Email = (string)context["Email"],
                Username = (string)context["Username"],
                Grade = Enum.GetValues<GradeType>()[(short)context["Grade"]],
                CreatedAt = (DateTime)context["CreatedAt"]
            };
        }
    }
}

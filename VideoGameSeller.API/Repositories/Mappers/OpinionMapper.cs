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
    public class OpinionMapper : Mapper<OpinionModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "User", new UserMapper(new string[] { "User"}) }
        };
        public OpinionMapper(IEnumerable<string> Prefix = null) : base(Prefix)
        {
        }

        public override OpinionModel MapReaderToModel(DataContext context)
        {
            return new OpinionModel
            {
                Id = (int)context["Id"],
                PublishedAt = (DateTime)context["PublishedAt"],
                Type = Enum.GetValues<OpinionType>()[(short)context["Type"]],
                User = UseMapper<UserModel>("User", context)
            };
        }
    }
}

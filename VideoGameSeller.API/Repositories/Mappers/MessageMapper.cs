using Models;
using Models.Form;
using Models.Form.RelationForm;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class MessageMapper : Mapper<MessageModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "User", new UserMapper(new string[]{ "User" }) }
        };

        public MessageMapper(IEnumerable<string> Prefix = null) : base(Prefix)
        {
        }

        public override MessageModel MapReaderToModel(DataContext context)
        {
            int id = (int)context["Id"];
            return new MessageModel
            {
                Message = (string)context["Message"],
                PublishedAt = (DateTime)context["PublishedAt"],
                User = UseMapper<UserModel>("User",context),
                Opinions = UseRepo<OpinionModel, OpinionMessageForm>("OpinionMessage", id)
            };
        }
    }
}

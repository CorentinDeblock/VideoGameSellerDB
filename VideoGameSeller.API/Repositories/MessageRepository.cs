using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repositories.Bases;
using VideoGameSeller.API.Repositories.Mappers;
using VideoGameSeller.API.Repositories.RelationRepository;

namespace VideoGameSeller.API.Repositories
{
    public class MessageRepository : Repository<MessageModel, MessageForm>
    {
        public MessageRepository(Connection connection) : base(connection)
        {

        }

        protected override Dictionary<string, object> ExternalRepository => new Dictionary<string, object> {
            { "OpinionMessage", new OpinionMessageRepository(Connection) }
        };

        protected override Mapper<MessageModel> Mapper => new MessageMapper();
    }
}

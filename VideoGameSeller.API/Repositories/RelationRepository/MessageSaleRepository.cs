using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repositories.Bases;
using VideoGameSeller.API.Repositories.Mappers;

namespace VideoGameSeller.API.Repositories.RelationRepository
{
    public class MessageSaleRepository : Repository<MessageModel, MessageSaleForm>
    {
        public MessageSaleRepository(Connection connection) : base(connection)
        {
            SetVerificationField("SaleId");
        }
        protected override Dictionary<string, object> ExternalRepository => new Dictionary<string, object> {
            { "OpinionMessage", new OpinionMessageRepository(Connection) }
        };

        protected override Mapper<MessageModel> Mapper => new MessageMapper();
    }
}

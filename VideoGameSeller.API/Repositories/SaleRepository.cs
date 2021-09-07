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
    public class SaleRepository : Repository<SaleModel, SaleForm>
    {
        public SaleRepository(Connection connection) : base(connection)
        {
        }

        protected override Dictionary<string, object> ExternalRepository => new Dictionary<string, object> {
            { "PlatformGame", new PlatformGameRepository(Connection) },
            { "SaleMessage", new MessageSaleRepository(Connection) },
            { "OpinionSale", new OpinionSaleRepository(Connection) },
            { "PictureSale", new PictureSaleRepository(Connection) },
            { "UserSale", new UserSaleRepository(Connection) }
        };

        protected override Mapper<SaleModel> Mapper => new SaleMapper();
    }
}

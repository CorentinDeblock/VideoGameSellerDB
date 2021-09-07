using Models;
using Models.Enum;
using Models.Form;
using Models.Form.RelationForm;
using Models.Model;
using System;
using System.Collections.Generic;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class SaleMapper : Mapper<SaleModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "Game", new GameMapper(new string[] {"Game"}) },
            { "Provider", new UserMapper(new string[] { "Provider" }) }
        };

        public SaleMapper(IEnumerable<string> Prefix = null) : base(Prefix)
        {
        }

        public override SaleModel MapReaderToModel(DataContext context)
        {
            int id = (int)context["Id"];

            return new SaleModel
            {
                Id = (int)context["Id"],
                Title = (string)context["Title"],
                Description = (string)context["Description"],
                Type = (SaleType)context["Type"],
                Price = (double)context["Price"],
                IsSale = (bool)context["IsSale"],
                PublishedAt = (DateTime)context["PublishedAt"],
                Game = UseMapper<GameModel>("Game", context),
                User = UseMapper<UserModel>("Provider", context),
                Messages = UseRepo<MessageModel, MessageSaleForm>("SaleMessage", id),
                Opinions = UseRepo<OpinionModel, OpinionSaleForm>("OpinionSale", id),
                Pictures = UseRepo<PictureModel, PictureSaleForm>("PictureSale", id),
                Interested = UseRepo<UserModel, UserSaleForm>("UserSale", id)
            };
        }
    }
}

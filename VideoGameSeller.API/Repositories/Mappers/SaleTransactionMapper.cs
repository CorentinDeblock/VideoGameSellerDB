using Models.Enum;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class SaleTransactionMapper : Mapper<SaleTransactionModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "Sale", new SaleMapper(new string[] { "Sale" }) }
        };

        public SaleTransactionMapper(IEnumerable<string> Prefix = null) : base(Prefix)
        {
        }

        public override SaleTransactionModel MapReaderToModel(DataContext context)
        {
            return new SaleTransactionModel {
                Price = (double)context["Price"],
                Type = (SaleTransactionType)context["Type"],
                Sale = UseMapper<SaleModel>("Sale", context)
            };
        }
    }
}

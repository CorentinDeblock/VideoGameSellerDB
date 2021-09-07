using Models.Form;
using Models.Form.RelationForm;
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
    public class OpinionSaleRepository : Repository<OpinionModel, OpinionSaleForm>
    {
        public OpinionSaleRepository(Connection connection) : base(connection)
        {
            SetVerificationField("SaleId");
        }

        protected override Mapper<OpinionModel> Mapper => new OpinionMapper();
    }
}

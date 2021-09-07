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
    public class PictureSaleRepository : Repository<PictureModel, PictureSaleForm>
    {
        public PictureSaleRepository(Connection connection) : base(connection)
        {
            SetVerificationField("SaleId");
        }

        protected override Mapper<PictureModel> Mapper => new PictureMapper();
    }
}

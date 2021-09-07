using Models;
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
    public class PlatformGameRepository : Repository<PlatformModel, PlatformGameForm>
    {
        public PlatformGameRepository(Connection connection) : base(connection)
        {
            SetVerificationField("GameId");
        }

        protected override Mapper<PlatformModel> Mapper => new PlatformMapper();
    }
}

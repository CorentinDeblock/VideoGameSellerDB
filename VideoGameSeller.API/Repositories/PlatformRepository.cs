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

namespace VideoGameSeller.API.Repositories
{
    public class PlatformRepository : Repository<PlatformModel, PlatformForm>
    {
        public PlatformRepository(Connection connection) : base(connection) { }

        protected override Mapper<PlatformModel> Mapper => new PlatformMapper();
    }
}

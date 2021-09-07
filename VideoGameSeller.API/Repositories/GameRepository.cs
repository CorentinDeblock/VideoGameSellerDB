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
    public class GameRepository : Repository<GameModel, GameForm>
    {
        public GameRepository(Connection connection) : base(connection)
        {
        }

        protected override Dictionary<string, object> ExternalRepository => new Dictionary<string, object> {
            { "PlatformGame", new PlatformGameRepository(Connection) }
        };

        protected override Mapper<GameModel> Mapper => new GameMapper();
    }
}

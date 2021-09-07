using Models;
using Models.Form;
using Models.Form.RelationForm;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;
using VideoGameSeller.API.Repositories.RelationRepository;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class GameMapper : Mapper<GameModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "Developer", new CompanyMapper(new string[]{ "Developer" }) },
            { "Publisher", new CompanyMapper(new string[]{ "Publisher" }) },
            { "Picture", new PictureMapper(new string[]{ "Picture"}) }
        };

        public GameMapper(IEnumerable<string> subfield = null) : base(subfield) {}

        public override GameModel MapReaderToModel(DataContext context)
        {
            int id = (int)context["Id"];
            return new GameModel
            {
                Id = id,
                Appearance = (DateTime)context["Appearance"],
                Description = (string)context["Description"],
                Name = (string)context["Name"],
                Developer = UseCompanyMapper("Developer",context),
                Publisher = UseCompanyMapper("Publisher", context),
                Picture = UseMapper<PictureModel>("Picture", context),
                Platforms = UseRepo<PlatformModel, PlatformGameForm>("PlatformGame", id)
            };
        }

        private CompanyModel UseCompanyMapper(string name, DataContext context)
        {
            return UseMapper<CompanyModel>(name, context);
        }
    }
}

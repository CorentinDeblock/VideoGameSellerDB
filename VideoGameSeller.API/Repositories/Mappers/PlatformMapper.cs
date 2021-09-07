using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class PlatformMapper : Mapper<PlatformModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object> {
            { "Picture", new PictureMapper(new string[] { "Picture" }) },
            { "Company", new CompanyMapper(new string[] { "Company" }) }
        };
        
        public PlatformMapper(IEnumerable<string> subfield = null) : base(subfield)
        {
        }

        public override PlatformModel MapReaderToModel(DataContext context)
        {
            return new PlatformModel
            {
                Id = (int)context["Id"],
                Name = (string)context["Name"],
                Description = (string)context["Description"],
                Appearance = (DateTime)context["Appearance"],
                Picture = UseMapper<PictureModel>("Picture", context),
                Company = UseMapper<CompanyModel>("Company", context)
            };
        }
    }
}

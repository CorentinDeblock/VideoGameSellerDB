using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class CompanyMapper : Mapper<CompanyModel>
    {
        protected override Dictionary<string, object> ExternalMapper => new Dictionary<string, object>{
            { "Picture", new PictureMapper(new string[] { "Picture" }) }
        };

        public CompanyMapper(IEnumerable<string> subfield = null) : base(subfield) {}

        public override CompanyModel MapReaderToModel(DataContext context)
        {
            return new CompanyModel
            {
                Id = (int)context["Id"],
                Appearance = (DateTime)context["Appearance"],
                Name = (string)context["Name"],
                Picture = UseMapper<PictureModel>("Picture", context)
            };
        }
    }
}

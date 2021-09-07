using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Repositories.Mappers
{
    public class PictureMapper : Mapper<PictureModel>
    {
        public PictureMapper(IEnumerable<string> subfield = null) : base(subfield)
        {
        }

        public override PictureModel MapReaderToModel(DataContext context)
        {
            return new PictureModel
            {
                Url = (string)context["Url"],
                PublishedAt = (DateTime)context["PublishedAt"]
            };
        }
    }
}

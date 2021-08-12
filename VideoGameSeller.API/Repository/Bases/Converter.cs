using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSeller.API.Repository.Bases
{
    public interface Converter<Entity,Model,Form>
    {
        Model ConvertEntityToModel(DbDataReader reader);
        Form ConvertEntityToForm(DbDataReader reader);
        Entity ConvertModelToEntity(Model model);
        Entity ConvertFormToEntity(Form form);
    }
}

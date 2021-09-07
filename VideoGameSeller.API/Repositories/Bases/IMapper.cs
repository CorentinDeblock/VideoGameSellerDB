using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSeller.API.Repositories.Bases
{
    public class DataContext
    {
        public DbDataReader Reader;
        public string Prefix = "";
        public IEnumerable<string> Fields;

        public DataContext(IEnumerable<string> field, DbDataReader reader)
        {
            Prefix = "";
            Fields = field;

            if(field != null)
                Prefix = string.Join(".", field) + ".";

            Reader = reader;
        }

        public object this[string field]
        {
            get
            {
                return Reader[Prefix + field];
            }
        }
    }

    public interface IMapper<Model>
    {
        Model MapReaderToModel(DataContext reader);
    }
}

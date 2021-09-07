using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSeller.API.Repositories.Bases
{
    public abstract class Mapper<Model> : IMapper<Model>
    { 
        private IEnumerable<string> _prefix;
        public Mapper(IEnumerable<string> Prefix = null)
        {
            _prefix = Prefix;
        }
        protected virtual Dictionary<string, object> ExternalMapper { get; }
        protected virtual Dictionary<string, object> ExternalRepo { get; private set; }

        public void SetRepo(Dictionary<string, object> externalRepo) => ExternalRepo = externalRepo;
        public M UseMapper<M>(string mapperName, DataContext context) 
        {
            Mapper<M> mapper = (Mapper<M>)ExternalMapper[mapperName];
            mapper.SetRepo(ExternalRepo);
            return mapper.MapReaderToModelFromMapper(context);
        }
        public IEnumerable<M> UseRepo<M, F>(string repository, int id) => ((IRepository<M, F>)ExternalRepo[repository]).GetMultiple(id);
        public abstract Model MapReaderToModel(DataContext context);

        public Model MapReaderToModelInternal(DbDataReader reader)
        {
            return MapReaderToModel(new DataContext(_prefix, reader));
        }

        public Model MapReaderToModelFromMapper(DataContext context)
        {
            return MapReaderToModel(new DataContext(FormatPrefix(context), context.Reader));
        }

        private IEnumerable<string> FormatPrefix(DataContext context)
        {
            if (context.Fields != null)
                return context.Fields.Concat(_prefix);
            return _prefix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSeller.API.Services
{
    public interface IRepository<Model,Form>
    {
        IEnumerable<Model> GetAll();
        Model Get(int id);
        void Insert(Form model);
        void Update(int id, Form model);
        bool Delete(int id);
    }
}

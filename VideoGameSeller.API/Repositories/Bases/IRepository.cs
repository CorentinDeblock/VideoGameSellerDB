using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSeller.API.Repositories.Bases
{
    public interface IRepository<Model, Form>
    {
        IEnumerable<Model> GetAll();
        Model Get(int id);
        IEnumerable<Model> GetMultiple(int id);
        Model Insert(Form forms);
        Model Update(int id, object obj);
        bool Delete(int id);

        IEnumerable<Model> Search(object obj, bool exact = false);
        Model SingleSearch(object obj, bool exact = false);

        IEnumerable<Model> CallProcedure(string name, object obj);
        Model SingleCallProcedure(string name, object obj);

        IRepository<ModelExternal, FormExternal> GetRepo<ModelExternal, FormExternal>(string name);
    }
}

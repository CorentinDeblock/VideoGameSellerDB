using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ToolBox.Database;

namespace VideoGameSeller.API.Repositories.Bases
{
    public abstract class Repository<Model,Form> : IRepository<Model, Form>
    {
        private string _viewName;
        private string _procedureName;

        private Mapper<Model> _mapper;
        private Connection _connection;
        private string _verificationField = "Id";
        private string _basename;

        protected Connection Connection;
        protected bool isInsertAProcedure = false;

        public Repository(Connection connection) 
        {
            Connection = connection;

            _basename = GetType().Name.Replace("Repository", "");

            _viewName = $"[dbo].[{_basename}View]";
            _procedureName = $"[dbo].[SP_{_basename}]";

            _mapper = Mapper;
            _connection = connection;
            _mapper.SetRepo(ExternalRepository);
        }

        protected abstract Mapper<Model> Mapper { get; }
        protected virtual Dictionary<string, object> ExternalRepository { get; }

        public IRepository<ModelExternal, FormExternal> GetRepo<ModelExternal, FormExternal>(string name) => 
            (IRepository<ModelExternal, FormExternal>)ExternalRepository[name];

        protected void SetView(string name) => _viewName = name;
        protected void SetVerificationField(string field) => _verificationField = field;

        public IEnumerable<Model> GetAll() => _connection.ExecuteReader(new Command($"SELECT * FROM {_viewName}"), _mapper.MapReaderToModelInternal);
        public Model Get(int id) => _connection.ExecuteReader(PrepareCommandWithId(id), _mapper.MapReaderToModelInternal).SingleOrDefault();
        public IEnumerable<Model> GetMultiple(int id) => _connection.ExecuteReader(PrepareCommandWithId(id), _mapper.MapReaderToModelInternal);
        public Model Insert(Form form) => _connection.ExecuteReader(PrepareProcedureInsertion(form), _mapper.MapReaderToModelInternal).SingleOrDefault();
        public Model Update(int id, object obj) => _connection.ExecuteReader(PrepareUpdate(id,obj), _mapper.MapReaderToModelInternal).SingleOrDefault();
        public bool Delete(int id) => _connection.ExecuteScalar<bool>(PrepareDelete(id));
        public IEnumerable<Model> Search(object obj,bool exact = false) => _connection.ExecuteReader(PrepareSearch(obj, exact), _mapper.MapReaderToModelInternal);
        public Model SingleSearch(object obj, bool exact = false) => _connection.ExecuteReader(PrepareSearch(obj, exact), _mapper.MapReaderToModelInternal).SingleOrDefault();

        public IEnumerable<Model> CallProcedure(string name, object obj) => _connection.ExecuteReader(PrepareProcedure(name, obj), _mapper.MapReaderToModelInternal);
        public Model SingleCallProcedure(string name, object obj) => _connection.ExecuteReader(PrepareProcedure(name, obj), _mapper.MapReaderToModelInternal).SingleOrDefault();

        private Command PrepareCommandWithId(int id)
        {
            Command cmd = new Command($"SELECT * FROM {_viewName} WHERE {_verificationField} = @id");
            cmd.AddParameter("id", id);
            return cmd;
        }

        private Command PrepareProcedureInsertion(Form form)
        {
            return PrepareProcedure(_procedureName, form);
        }

        private Command PrepareUpdate(int id, object obj)
        {
            ObjectDescriptor<object> objectDescriptor = new (obj);
            Command cmd = new Command($"UPDATE {_basename} SET {objectDescriptor.GetFields()} WHERE {_verificationField} = @Id");
            objectDescriptor.PutParameters(cmd);
            cmd.AddParameter("Id", id);

            return cmd;
        }

        private Command PrepareDelete(int id)
        {
            Command cmd = new Command($"DELETE {_basename} WHERE {_verificationField} = @Id");
            cmd.AddParameter("Id", id);

            return cmd;
        }

        private Command PrepareSearch(object obj, bool exact)
        {
            ObjectDescriptor<object> objectDescriptor = new (obj);
            Command cmd = new Command($"SELECT * FROM {_viewName} WHERE {objectDescriptor.GetFields(exact)}");
            objectDescriptor.PutParameters(cmd);

            return cmd;
        }

        private Command PrepareProcedure<Object>(string procedure, Object obj)
        {
            ObjectDescriptor<Object> objectDescriptor = new (obj);
            Command cmd = new Command(procedure, true);
            objectDescriptor.PutParameters(cmd);

            return cmd;
        }
    }
}

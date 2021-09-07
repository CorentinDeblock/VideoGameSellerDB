using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ToolBox.Database;

namespace VideoGameSeller.API.Repositories.Bases
{
    public class ObjectDescriptor<Form>
    {
        private Dictionary<string, object> data = new Dictionary<string, object>();

        public ObjectDescriptor(Form model)
        {
            PropertyInfo[] t = model.GetType().GetProperties(); ;

            foreach (PropertyInfo field in t)
                data.Add(field.Name, field.GetValue(model));
        }

        public string GetFields(bool exact = false)
        {
            return string.Join(" AND ", data.Keys.Select(e => $"[{e.Replace("_", ".")}] = {(exact ? "%" : "")}@{e}"));
        }

        public void PutParameters(Command cmd)
        {
            cmd.AddParameters(data);
        }
    }

    public class ProcedureCall
    {
        private string _procedure;
        private Connection _connection;
        public ProcedureCall(string procedure, Connection connection)
        {
            _procedure = procedure;
            _connection = connection;
        }

        public void Call<Object>(Object obj)
        {
            ObjectDescriptor<Object> objectDescriptor = new(obj);
            Command cmd = new Command(_procedure, true);
            objectDescriptor.PutParameters(cmd);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}

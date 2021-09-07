using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace ToolBox.Database
{
    using ObjectData = Dictionary<string, object>;
    using WhereData = Dictionary<string, object>;
    using JoinData = List<Join>;
    internal class ObjectDescriptor
    {
        public ObjectData data = new ObjectData();

        public object Obj;
        public string Name = "";

        public static ObjectDescriptor CreateDescriptor<Object>(Object entity,string name = "")
        {
            PropertyInfo[] info = entity.GetType().GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            descriptor.Obj = entity;
            descriptor.Name = name;

            for (int i = 0; i < info.Length; i++)
                descriptor.data.Add($"{info[i].Name}", info[i].GetValue(entity));
            return descriptor;
        }

        public static ObjectDescriptor CreateDescriptor<Object>(string name = "")
        {
            PropertyInfo[] info = typeof(Object).GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            descriptor.Obj = typeof(Object);
            descriptor.Name = name;

            for (int i = 0; i < info.Length; i++)
                descriptor.data.Add($"{info[i].Name}", null);
            return descriptor;
        }

        public string FieldEquals()
        {
            List<string> delimited = new List<string>();
            foreach (KeyValuePair<string, object> pair in data)
                delimited.Add($"{pair.Key} = @{pair.Key}");
            return string.Join(",",delimited);
        }

        public string Join()
        {
            return string.Join(",", data.Keys);
        }

        public string Prepare()
        {
            return string.Join(",",data.Keys.Select((string data) => $"@{data}"));
        }

        public void PutParameters(Command cmd)
        {
            cmd.AddParameters(data);
        }
    }
    public enum JoinType { INNER, LEFT, RIGHT, OUTER}

    public class Join
    {
        public Join(JoinType type, string target, string firstField, string secondField)
        {
            Type = type;
            Target = target;
            FirstField = firstField;
            SecondField = secondField;
        }

        public JoinType Type = JoinType.INNER;
        public string Target;
        public string FirstField;
        public string SecondField;
    }

    public class BuildedQuery
    {
        public string Field = "";
        public string Where = "";
        public string Join = "";
        public WhereData WhereEquals = new WhereData();
        public JoinData JoinEquals = new JoinData();
        public void PutParameters(Command cmd)
        {
            cmd.AddParameters(WhereEquals);
        }
    }
    public class QueryOption
    {
        public List<string> Field = new List<string>();
        public WhereData Where = new WhereData();
        public JoinData Join = new JoinData();
        public List<string> Ignore = new List<string>();
        public BuildedQuery BuildQuery()
        {
            BuildedQuery buildedQuery = new BuildedQuery();

            if(Field.Count != 0)
                buildedQuery.Field = string.Join(',', Field);

            if(Where.Count != 0)
                buildedQuery.Where = $"WHERE {string.Join(',', Where.Select(pair => $"{pair.Key} = @{pair.Key}"))}";

            foreach(Join pair in Join)
            {
                buildedQuery.Join = $"{pair.Type} JOIN {pair.Target} ON {pair.FirstField} = {pair.SecondField}";
            }

            buildedQuery.WhereEquals = Where;
            buildedQuery.JoinEquals = Join;

            return buildedQuery;
        }
    }
    public class CRUD
    {
        private Connection _connection;
        private string _table;

        public CRUD(string name,Connection connection = null)
        {
            if (connection == null)
                throw new Exception("Please provide a connection into your api or asp via the function addSingleton<Connection>()");
            _connection = connection;
            _table = $"[dbo].[{name}]";
        }

        public void Create<Object>(Object entity)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(entity);
            Command cmd = new Command($"INSERT INTO {_table}({descriptor.Join()}) VALUES({descriptor.Prepare()})");
            descriptor.PutParameters(cmd);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<T> Read<T>(Func<DbDataReader,T> func, QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = CheckOption<T>(queryOption);
            Command cmd = new Command($"SELECT {buildedQuery.Field} FROM {_table} {buildedQuery.Where} {buildedQuery.Join}");
            buildedQuery.PutParameters(cmd);
            return _connection.ExecuteReader(cmd, func);
        }

        public void Update<Object>(Object obj, QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = CheckOption<Object>(queryOption);
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(obj);
            string Query = $"UPDATE {_table} SET {descriptor.FieldEquals()} {buildedQuery.Where}";

            Command cmd = new Command(Query);

            descriptor.PutParameters(cmd);
            buildedQuery.PutParameters(cmd);

            _connection.ExecuteNonQuery(cmd);
        }

        public bool Delete(QueryOption queryOption)
        {
            BuildedQuery buildedQuery = CheckOption(queryOption);
            string Query = $"DELETE FROM {_table} {buildedQuery.Where}";

            Command cmd = new Command(Query);
            buildedQuery.PutParameters(cmd);

            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        private BuildedQuery CheckOption<T>(QueryOption queryOption)
        {
            BuildedQuery buildedQuery = CheckOption(queryOption);

            List<string> BuildedField = new List<string>();
            ObjectDescriptor objectDescriptor = ObjectDescriptor.CreateDescriptor<T>();

            foreach (string field in objectDescriptor.data.Keys.ToList())
            {
                if (!queryOption.Ignore.Contains(field))
                    BuildedField.Add(field);
            }
            buildedQuery.Field = string.Join(",", BuildedField);

            return buildedQuery;
        }

        private BuildedQuery CheckOption(QueryOption queryOption)
        {
            BuildedQuery buildedQuery = new BuildedQuery();

            if (queryOption != null)
                buildedQuery = queryOption.BuildQuery();

            return buildedQuery;
        }
    }
}

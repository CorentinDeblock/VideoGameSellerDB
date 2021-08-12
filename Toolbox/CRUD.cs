using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace ToolBox.Database
{
    internal class ObjectDescriptor
    {
        public Dictionary<string, object> data = new Dictionary<string, object>();
        public List<ObjectDescriptor> Clauses = new List<ObjectDescriptor>();
        public object Obj;
        public string Name = "";

        private string[] ReservedKeyword = { "WHERE" };

        public static ObjectDescriptor CreateDescriptor<Object>(Object entity,string name = "")
        {
            PropertyInfo[] info = entity.GetType().GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            descriptor.Obj = entity;
            descriptor.Name = name;

            for (int i = 0; i < info.Length; i++)
            {
                if (descriptor.ReservedKeyword.Contains(info[i].Name))
                {
                    ObjectDescriptor clausesDescriptor = CreateDescriptor(info[i].GetValue(entity), info[i].Name);
                    descriptor.Clauses.Add(clausesDescriptor);
                }else
                    descriptor.data.Add(info[i].Name, info[i].GetValue(entity));
            }
            return descriptor;
        }

        public string FieldEquals()
        {
            List<string> delimited = new List<string>();
            foreach (KeyValuePair<string, object> pair in data)
                delimited.Add($"{pair.Key} = @{pair.Key}");
            return string.Join(",",delimited);
        }

        public string GetAllClauses()
        {
            string ClausesStr = "";

            foreach (ObjectDescriptor Clause in Clauses)
                ClausesStr += $" {Clause.Name} {Clause.FieldEquals()} ";
            return ClausesStr;
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
            foreach (ObjectDescriptor Clause in Clauses)
            {
                cmd.AddParameters(Clause.data);
            }
        }
    }

    public class QueryOption
    {
        public List<string> Field { get; set; } = new List<string>();
        public Dictionary<string, object> Where { get; set; } = new Dictionary<string, object>();
    }

    internal class BuildedQuery
    {
        public string Field { get; set; } = "*";
        public string Where { get; set; } = "";
    }
    public class CRUD
    {
        private Connection Connection;
        private string Table;

        public CRUD(string name,Connection connection = null)
        {
            if (connection == null)
                throw new Exception("Please provide a connection into your api or asp via the function addSingleton<Connection>()");
            Connection = connection;
            Table = $"[dbo].[{name}]";
        }

        public void Create<Object>(Object entity)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(entity);
            Command cmd = new Command($"INSERT INTO {Table}({descriptor.Join()}) VALUES({descriptor.Prepare()})");
            descriptor.PutParameters(cmd);

            Connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<T> Read<T>(Func<DbDataReader,T> func, QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = BuildQuery(queryOption);
            Command cmd = new Command($"SELECT {buildedQuery.Field} FROM {Table} {buildedQuery.Where};");
            return Connection.ExecuteReader(cmd, func);
        }

        public void Update<Object>(Object obj)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(obj);
            string Query = $"UPDATE {Table} SET {descriptor.FieldEquals()}{descriptor.GetAllClauses()}";

            Command cmd = new Command(Query);

            descriptor.PutParameters(cmd);

            Connection.ExecuteNonQuery(cmd);
        }

        public bool Delete<Object>(Object obj)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(obj);
            string Query = $"DELETE FROM {Table}{descriptor.GetAllClauses()}";

            Command cmd = new Command(Query);
            descriptor.PutParameters(cmd);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        private BuildedQuery BuildQuery(QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = new BuildedQuery();

            if (queryOption != null)
            {
                if(queryOption.Field.Count > 0)
                    buildedQuery.Field = string.Join(',', queryOption.Field);
                buildedQuery.Where = $"WHERE {string.Join(',', queryOption.Where.Select(pair => $"{pair.Key} = '{pair.Value}'"))}";
            }

            return buildedQuery;
        }
    }
}

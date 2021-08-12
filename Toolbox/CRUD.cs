using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    internal class ObjectDescriptor
    {
        public Dictionary<string, object> data;
        public object Obj;
        
        public static ObjectDescriptor CreateDescriptor<Object>(Object entity)
        {
            PropertyInfo[] info = entity.GetType().GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            descriptor.Obj = entity;

            for (int i = 0; i < info.Length; i++)
            {
                descriptor.data.Add(info[i].Name, info[i].GetValue(entity));
            }

            return descriptor;
        }

        public string GetWhere()
        {
            List<string> delimited = new List<string>();
            foreach (KeyValuePair<string, object> pair in data)
                delimited.Add($"{pair.Key} = {Obj.GetType().GetProperty(pair.Key).GetValue(Obj)}");
            return string.Join(",",delimited);
        }

        public string Prepare()
        {
            return string.Join(",",data.Keys.Select((string data) => $"@{data}"));
        }
    }

    public class QueryOption
    {
        public List<string> Field { get; set; } = new List<string>();
        public Dictionary<string, string> Where { get; set; } = new Dictionary<string, string>();
    }

    internal class BuildedQuery
    {
        public string Field { get; set; } = "*";
        public string Where { get; set; } = "";
    }
    public class CRUD<T>
    {
        private Connection Connection;
        private string ClassName = typeof(T).Name;

        public CRUD(Connection connection)
        {
            if (connection == null)
                throw new Exception("Please provide a connection into your api or asp via the function addScoped<Connection>()");
            Connection = connection;
        }

        public void Create<Object>(Object entity)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(entity);
            Command cmd = new Command($"INSERT INTO {ClassName} VALUES({descriptor.Prepare()})");
            cmd.SetParameters(descriptor.data);

            Connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<T> Read(Func<DbDataReader,T> func, QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = BuildQuery(queryOption);
            Command cmd = new Command($"SELECT {buildedQuery.Field} FROM [dbo].[{ClassName}] {buildedQuery.Where};");
            return Connection.ExecuteReader(cmd, (DbDataReader reader) =>
            {
                return func(reader);
            });
        }

        private ObjectDescriptor GetDescriptionFromObject<Object>(Object entity)
        {
            PropertyInfo[] info = entity.GetType().GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            for (int i = 0; i < info.Length; i++)
            {
                descriptor.data.Add(info[i].Name,info[i].GetValue(entity));
            }

            return descriptor;
        }

        private BuildedQuery BuildQuery(QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = new BuildedQuery();

            if (queryOption != null)
            {
                buildedQuery.Field = string.Join(',', queryOption.Field);
                buildedQuery.Where = $"WHERE {string.Join(',', queryOption.Where.Select(pair => $"{pair.Key} = '{pair.Value}'"))}";
            }

            return buildedQuery;
        }
    }
}

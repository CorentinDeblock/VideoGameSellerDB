using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Test
{
    internal class ObjectDescriptor
    {
        public Dictionary<string, object> data = new Dictionary<string, object>();

        public static ObjectDescriptor CreateDescriptor<Object>(Object entity)
        {
            PropertyInfo[] info = entity.GetType().GetProperties();
            ObjectDescriptor descriptor = new ObjectDescriptor();

            foreach(PropertyInfo pinfo in info)
            {
                descriptor.data.Add(pinfo.Name, pinfo.GetValue(entity));
            }

            return descriptor;
        }

        public string GetWhere()
        {
            List<string> delimited = new List<string>();
            foreach (KeyValuePair<string, object> pair in data)
                delimited.Add($"{pair.Key} = {pair.Value}");
            return string.Join(",", delimited);
        }

        public string Prepare()
        {
            return string.Join(",", data.Keys.Select((string data) => $"@{data}"));
        }

        public string GetFields()
        {
            return string.Join(",", data.Keys);
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
    class CRUD<T>
    {
        private string ClassName = typeof(T).Name;

        public string Create(T entity)
        {
            ObjectDescriptor descriptor = ObjectDescriptor.CreateDescriptor(entity);
            Console.WriteLine(descriptor.GetWhere());
            return $"INSERT INTO {ClassName} VALUES({descriptor.Prepare()})";
        }

        public string Read(QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = BuildQuery(queryOption);
            return $"SELECT {buildedQuery.Field} FROM {ClassName} {buildedQuery.Where}";
        }

        private BuildedQuery BuildQuery(QueryOption queryOption = null)
        {
            BuildedQuery buildedQuery = new BuildedQuery();

            if (queryOption != null)
            {
                buildedQuery.Field = string.Join(',',queryOption.Field);
                buildedQuery.Where = $"WHERE {string.Join(',', queryOption.Where.Select(pair => $"{pair.Key} = {pair.Value}"))}";
            }

            return buildedQuery;
        }
    }

    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            CRUD<User> Crud = new CRUD<User>();

            Console.WriteLine(Crud.Read());
        }
    }
}

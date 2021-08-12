using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ToolBox.Database
{
    /// <summary>
    /// Classe qui va simplifier la connection en ado en réimplémentant 
    /// les méthodes ExecuteNonQuery, ExecuteReader et ExecuteScalars
    /// </summary>
    public class Connection
    {
        private DbProviderFactory _factory;
        private string _connectionString;
        public Connection(DbProviderFactory factory,string connectionString)
        {
            _factory = factory;
            _connectionString = connectionString;
        }

        public int ExecuteNonQuery(Command command)
        {
            using (DbConnection con = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(con, command))
                {
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public T ExecuteScalar<T>(Command command)
        {
            using (DbConnection con = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(con, command))
                {
                    con.Open();
                    return (T)cmd.ExecuteScalar();
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(Command command,Func<DbDataReader,T> func)
        {
            using (DbConnection con = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(con, command))
                {
                    con.Open();
                    using (DbDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                            yield return func(r);
                    }
                }
            }
        }

        /// <summary>
        /// Crée une connection vers une base de données sql
        /// </summary>
        private DbConnection CreateConnection()
        {
            DbConnection con = _factory.CreateConnection();
            con.ConnectionString = _connectionString;
            return con;
        }

        private DbCommand CreateCommand(DbConnection con, Command command)
        {
            DbCommand cmd = con.CreateCommand();
            // quid ? de la query et des parametres
            cmd.CommandText = command.CommandText;
            foreach (KeyValuePair<string, object> pair in command.Parameters)
            {
                DbParameter p = cmd.CreateParameter();
                p.ParameterName = pair.Key;
                p.Value = pair.Value ?? DBNull.Value;
                cmd.Parameters.Add(p);
            }
            if (command.IsStoredProcedure)
                cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
    }

    //public class MyConnection
    //{
    //    private delegate void Callback();
    //    private DbProviderFactory _factory;

    //    public MyConnection(DbProviderFactory factory)
    //    {
    //        _factory = factory;
    //    }

    //    public int ExecuteNonQuery()
    //    {
    //        Query(delegate() { });
    //        return 0;
    //    }

    //    public T ExecuteScalar<T>()
    //    {
    //        Query(delegate () { });
    //        return default;
    //    }

    //    public List<T> ExecuteReader<T>()
    //    {
    //        Query(delegate () { });
    //        return new List<T>();
    //    }

    //    private void Query(Command command,Callback callback)
    //    {
    //        using (DbConnection conn = CreateConnection())
    //        {
    //            DbCommand cmd = CreateCommand(conn, command);
    //            conn.Open();
    //            callback();
    //        }
    //    }

    //    private DbCommand CreateCommand(DbConnection conn,Command command)
    //    {
    //        DbCommand cmd = conn.CreateCommand();
    //        return cmd;
    //    }

    //    private DbConnection CreateConnection()
    //    {
    //        return _factory.CreateConnection();
    //    }
    //}
}

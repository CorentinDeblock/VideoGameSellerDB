using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Services;

namespace VideoGameSeller.API.Repository
{
    public abstract class Repository
    {
        protected CRUD CRUD;
        public Repository(Connection connection, string tableName)
        {
            CRUD = new CRUD(tableName,connection);
        }


    }
}

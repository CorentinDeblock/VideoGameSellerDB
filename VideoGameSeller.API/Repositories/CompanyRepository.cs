using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using ToolBox.Database;
using VideoGameSeller.API.Repositories.Bases;
using VideoGameSeller.API.Repositories.Mappers;

namespace VideoGameSeller.API.Repositories
{
    public class CompanyRepository : Repository<CompanyModel, CompanyForm>
    {
        public CompanyRepository(Connection connection) : base(connection) {}

        protected override Mapper<CompanyModel> Mapper => new CompanyMapper();
    }
}

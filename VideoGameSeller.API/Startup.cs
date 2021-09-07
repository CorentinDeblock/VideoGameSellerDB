using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repositories;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton(new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("SQL")));

            services.AddScoped<IRepository<CompanyModel, CompanyForm>, CompanyRepository>();
            services.AddScoped<IRepository<PlatformModel, PlatformForm>, PlatformRepository>();
            services.AddScoped<IRepository<GameModel, GameForm>, GameRepository>();
            services.AddScoped<IRepository<SaleModel, SaleForm>, SaleRepository>();
            services.AddScoped<IRepository<MessageModel, MessageForm>, MessageRepository>();
            services.AddScoped<IRepository<UserModel, UserForm>, UserRepository>();
            services.AddScoped<IRepository<SaleTransactionModel, SaleForm>, SaleTransactionRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoGameSeller.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoGameSeller.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

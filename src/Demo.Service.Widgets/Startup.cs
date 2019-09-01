using AutoMapper;
using Demo.Service.Common;
using Demo.Service.Common.Exceptions;
using Demo.Service.Common.Extensions;
using Demo.Service.Widgets.Domain.Database;
using Demo.Service.Widgets.Domain.DataContext;
using Demo.Service.Widgets.Domain.DataModel;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Service.Widgets
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTenantContext();
            services.AddDatabase<DbTenantContext>(_configuration.GetSqlConnectionString());
            services.AddDatabase<DbGlobalContext>(_configuration.GetSqlConnectionString());
            services.AddDatabaseMigrations<Migration1>(_configuration.GetSqlConnectionString());
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddCustomHealthChecks(_configuration.GetSqlConnectionString());
            services.AddCustomSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCustomHealthChecks();
            app.UseCustomSwagger();
            app.UseCustomMetaEndpoints();
            app.UseMvc();
            app.UseDatabase();
            app.UseDatabaseMigrations();
        }
    }
}

using Demo.Service.Common.Context;
using Demo.Service.Common.Exceptions;
using FluentMigrator.Runner;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Service.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTenantContext(this IServiceCollection services) =>
            services
                .AddScoped<ITenantContext, RequestContext>()
                .AddScoped<IUserContext, RequestContext>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(MicroServiceContext.ApiVersion, new Info { Title = MicroServiceContext.Name, Version = MicroServiceContext.ApiVersion });
                var xmlFile = $"{MicroServiceContext.Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(i => i.FullName);
                c.DescribeAllEnumsAsStrings();
            });
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                // For postman integration
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    // if postman is in the query, generate a postman compatible swagger file
                    if (httpReq.Query.ContainsKey("postman"))
                    {
                        swaggerDoc.Host = "{{host}}";
                        swaggerDoc.Schemes = new string[] { "http" };
                    }
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{MicroServiceContext.Name} {MicroServiceContext.Version}");
                c.RoutePrefix = "";
            });
            return app;
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connection) where T : DbContext =>
            services
                .AddDbContext<T>(c =>
                {
                    c.UseSqlServer(connection);
                });

        public static IServiceCollection AddDatabaseMigrations<T>(this IServiceCollection services, string connection) =>
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connection)
                    .ScanIn(typeof(T).Assembly).For.All());

        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, string connectionString)
        {
            services.AddHealthChecksUI();
            services.AddHealthChecks()
                .AddCheck("api", () => HealthCheckResult.Healthy())
                .AddSqlServer(connectionString, name: "db");
            return services;
        }

        public static IApplicationBuilder UseCustomHealthChecks(this IApplicationBuilder app)
            => app
                .UseHealthChecksUI()
                .UseHealthChecks("/health/alive", new HealthCheckOptions
                {
                    Predicate = r => r.Name == "api",
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                })
                .UseHealthChecks("/health/ready", new HealthCheckOptions
                {
                    Predicate = r => r.Name == "db",
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

        public static IApplicationBuilder UseCustomMetaEndpoints(this IApplicationBuilder app)
            => app
                .Map("/app/name", appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        await context.Response.WriteAsync(MicroServiceContext.Name);
                    });
                })
                .Map("/app/version", appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        await context.Response.WriteAsync(MicroServiceContext.Version);
                    });
                })
                .Map("/app/config", appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var d = new Dictionary<string, string>();
                        var configuration = appBuilder.ApplicationServices.GetRequiredService<IConfiguration>();
                        foreach (var entry in configuration.AsEnumerable().OrderBy(x => x.Key))
                        {
                            d.Add(entry.Key, entry.Value);
                        }
                        var json = JsonConvert.SerializeObject(d);
                        await context.Response.WriteAsync(json);
                    });
                })
                .Map("/errors/internal", appBuilder =>
                {
                    appBuilder.Run(context =>
                    {
                        throw new Exception("ERROR!");
                    });
                })
                .Map("/errors/notfound", appBuilder =>
                {
                    appBuilder.Run(context =>
                    {
                        throw new NotFoundException("entity", "property", "value");
                    });
                })
                .Map("/errors/notunique", appBuilder =>
                {
                    appBuilder.Run(context =>
                    {
                        throw new NotUniqueException("entity", "property", "value");
                    });
                });

    }
}
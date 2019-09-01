using Demo.Service.Tenants.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Service.Tenants
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.CreateTenantPolicy, c =>
                {
                    c.RequireClaim(Constants.CreateTenantClaim);
                });
                options.AddPolicy(Constants.ReadDomainsPolicy, c =>
                {
                    c.RequireClaim(Constants.ReadDomainsClaim);
                });
                options.AddPolicy(Constants.ManageUsersPolicy, c =>
                {
                    c.RequireClaim(Constants.ManageUserClaim);
                });
                options.AddPolicy(Constants.ManageTenantPolicy, c =>
                {
                    c.RequireClaim(Constants.ManageTenantClaim);
                });
                options.AddPolicy(Constants.ReadTenantsPolicy, c =>
                {
                    c.RequireClaim(Constants.ReadTenantsClaim);
                });
                options.AddPolicy(Constants.ManageTenantsPolicy, c =>
                {
                    c.RequireClaim(Constants.ManageTenantsClaim);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MOD.SearchService.DBContexts;
using MOD.SearchService.Infrastructure;
using MOD.SearchService.Repository;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MOD.SearchService
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
            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContextPool<SearchContext>
                (o => o.UseSqlServer(Configuration.GetConnectionString("MODDB")));
            services.AddTransient<ISearchRepository, SearchRepository>();

            services.AddSingleton<IHostedService, ConsulHostedService>();
            services.Configure<ConsulConfig>(
                Configuration.GetSection("consulConfig"));
            services.AddTransient<IConsulClient, ConsulClient>(
                p => new ConsulClient(
                consulConfig =>
                {
                    var address = Configuration["consulConfig:address"];
                    consulConfig.Address = new Uri(address);
                }
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

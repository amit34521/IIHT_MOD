using Consul;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MOD.AuthenticationService.DBContexts;
using MOD.AuthenticationService.Infrastructure;
using MOD.AuthenticationService.Repository;
using System;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MOD.AuthenticationService
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContextPool<AuthenticationContext>
                (o => o.UseSqlServer(Configuration.GetConnectionString("MODDB")));
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters =
            //        new TokenValidationParameters()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidIssuer = "iiht.com",
            //            ValidAudience = "trainees",
            //            IssuerSigningKey =
            //                new SymmetricSecurityKey(
            //                    Encoding.UTF8.GetBytes(
            //                        "MyKeyForAuthentication"))
            //        };
            //});

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

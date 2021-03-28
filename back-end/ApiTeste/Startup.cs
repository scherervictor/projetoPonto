using ApiTeste.Application.Interfaces.Services;
using ApiTeste.Application.Services;
using ApiTeste.Domain.Interfaces.Repository;
using ApiTeste.Infra.Configuration;
using ApiTeste.Infra.MySQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace ApiTeste
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IPontoService, PontoService>();
            services.AddScoped<IPontoRepository, MySQLPontoRepository>();

            var connectionString = Configuration.GetValue<string>("MySQLConnectionString");            

            services.AddSingleton(new MySQLConfiguration { ConnectionString = connectionString });

            services.AddCors(options => {
                options.AddPolicy("mypolicy", builder => builder
                 .WithOrigins("http://localhost:4200")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(p => p.Build());
            app.UseMvc();
        }
    }
}

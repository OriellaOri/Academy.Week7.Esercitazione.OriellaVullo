using Academy.Week7.Esercitazione.Core1.BL;
using Academy.Week7.Esercitazione.Core1.Interfaces;
using Academy.Week7.Esercitazione.EF1;
using Academy.Week7.Esercitazione.EF1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Academy.Week7.Esercitazione.API
{
    public class Startup
    {
        /* SWAGGER */
        public readonly string ApplicationName =
            Assembly.GetEntryAssembly().GetName().Name;
        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /* SWAGGER */
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });

                //le righe seguenti se si vuole che le SUMMARY siano VISIBILI nel SWAGGER
                string file = $"{typeof(Startup).Assembly.GetName().Name}.xml";
                string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                c.IncludeXmlComments(xmlPath);
            });

            // DI Configuration
            services.AddTransient<IMainBL, MainBL>();
            services.AddTransient<IOrderRepository, EfOrderRepository>();
            // aggiunto anche Client senò dava errore nella DEPENDENCY INJECTION
            services.AddTransient<IClientRepository, EfClientRepository>();

            services.AddDbContext<EsercitazioneContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OrdiniDb"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            /* SEAGGER */
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

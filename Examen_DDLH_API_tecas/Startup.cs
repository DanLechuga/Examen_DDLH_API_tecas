using API_Aplicacion.Implentaciones;
using API_Aplicacion.Interfaces;
using API_Comun;
using API_Infraestructura.Implementaciones;
using API_Infraestructura.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_DDLH_API_tecas
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
            services.AddTransient<IUnidadDetrabajo>(uni => new UnidadDeTrabajo(Configuration.GetConnectionString("Base1")));
            services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
            services.AddTransient<IRepositorioCuentas, RepositorioCuenta>();
            services.AddTransient<IRepositorioHistorial, RepositorioHistorial>();
            services.AddTransient<IRepositorioReportesSemanales, RepositorioReportesSemanales>();
            services.AddTransient<IServicioReportesSemanales, ServicioReportesSemanales>();
            services.AddTransient<IServicioHistorial, ServicioHistorial>();
            services.AddTransient<IValidacionUsuarios, ValidacionUsuarios>();
            services.AddTransient<IMovimientosCuentas, MovimientosCuentas>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examen_DDLH_API_tecas", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examen_DDLH_API_tecas v1"));
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

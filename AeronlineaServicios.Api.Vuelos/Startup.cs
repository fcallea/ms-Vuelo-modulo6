using AerolineaServicios.Rabbitmq.BusRabbit;
using AerolineaServicios.Rabbitmq.EventoQueue;
using AerolineaServicios.Rabbitmq.Implement;
using AeronlineaServicios.Api.Vuelos.Aplicacion;
using AeronlineaServicios.Api.Vuelos.ManajadorRabbit;
using AeronlineaServicios.Api.Vuelos.ManajadorRabbit.ManejadorAeronave;
using AeronlineaServicios.Api.Vuelos.ManajadorRabbit.ManejadorAeropuertos;
using AeronlineaServicios.Api.Vuelos.ManajadorRabbit.ManejadorTripulacion;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos
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
            services.AddTransient<IRabbitEventBus, RabbitEventBus>();

            services.AddTransient<ContextoVuelo>();

            //implementacion logica de evento manejador
            services.AddTransient<IEventoManejador<TripulacionEventoQueue>, TripulacionCreadaEventoManejador>();
            //services.AddTransient<IEventoManejador<AeronaveAgregadaEventoQueue>, AeronaveAgregadaEventoManejador>();
            services.AddTransient<IEventoManejador<AeropuertoCreadoQueue>, AeropuertoCreadoEventoManejador>();

            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<NuevoDestinoVuelo>());

            services.AddDbContext<ContextoVuelo>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDB"));
            });

            services.AddMediatR(typeof(NuevoDestinoVuelo.CrearDestinoVueloHandler).Assembly);

            services.AddMediatR(typeof(NuevoGuardarTripulacion.GuardarTripulacionHandler).Assembly);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Web Api Vuelos", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Habilitar swagger
            app.UseSwagger();

            //indica la ruta para generar la configuración de swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api Vuelos");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();

            eventBus.Subscribe<TripulacionEventoQueue, TripulacionCreadaEventoManejador>();

            //eventBus.Subscribe<AeropuertoCreadoQueue, AeropuertoCreadoEventoManejador>();

            eventBus.Subscribe<AeronaveAgregadaEventoQueue, AeronaveAgregadaEventoManejador>();
        }
    }
}

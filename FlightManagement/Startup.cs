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
using FlightManagement.Data;
using FlightManagement.Data.InMemory;
using FlightManagement.Data.Sql;
using FlightManagement.Models;
using FlightManagement.Services.AirplaneService;
using FlightManagement.Services.AirportService;
using FlightManagement.Services.FlightService;
using FlightManagement.Services.GpsService;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightManagement", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

            });
            services.AddScoped<IAirplaneRepository, SqlAirplaneRepository>();
            services.AddScoped<IFlightRepository, SqlFlightRepository>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IGpsService, GpsService>();
            services.AddScoped<IAirportRepository, SqlAirportRepository>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IAirPlaneService, AirplaneService>();

            services.AddSingleton<IBaseRepository<Airplane>, InMemoryAirplaneRepository>();
            services.AddSingleton<IBaseRepository<Flight>, InMemoryFlightRepository>();
            services.AddSingleton<IBaseRepository<Airport>, InMemoryAirportRepository>();


            services.AddDbContext<DataContext>(op => op.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddMvc();
            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

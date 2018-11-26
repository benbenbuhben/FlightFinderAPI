using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlightFinderAPI.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace FlightFinderAPI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FlightContext>(options => options.UseSqlite("Data Source=./wwwroot/FlightFinder.db"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen( c => 
            {
                c.SwaggerDoc("v1", new Info { Title="Flight Finder API", Description="Swagger Docs"});
            }

            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
            );

            // app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
                    
                routes.MapRoute(
                    name: "flights",
                    template: "{controller=Flights}/{action}/{id?}");

                routes.MapRoute(
                    name: "airports",
                    template: "{controller=Airports}/{action}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI( c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Finder API");
            }
            );

            
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlightFinderAPI.Models;

namespace FlightFinderAPI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FlightContext>(options => options.UseSqlite("Data Source=./wwwroot/FlightFinder.db"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                    template: "{controller=Flights}/{action}/{id?}");

                routes.MapRoute(
                    name: "airports",
                    template: "{controller=Airports}/{action}/{id?}");
            });

            
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FlightFinderAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FlightContext(serviceProvider.GetRequiredService<DbContextOptions<FlightContext>>()))
            {
                if (!context.Airport.Any())
                {
                    string airportsCsvFilepath = "./SampleData/airports.csv";
                    using (StreamReader reader = File.OpenText(airportsCsvFilepath))
                    {
                      var airportsCsv = new CsvReader(reader);
                      airportsCsv.Configuration.RegisterClassMap<AirportMap>();
                      var airports = airportsCsv.GetRecords<Airport>();
                      foreach(var airport in airports)
                      {
                        context.Airport.Add(airport);
                      }
                      context.SaveChanges();
                    }
                
                context.SaveChanges();
                }

                // Consider refactoring to call a SeedMissing method to make DRY-er.
                if (!context.Flight.Any())
                {
                    string flightsCsvFilepath = "./SampleData/flights.csv";
                    using (StreamReader reader = File.OpenText(flightsCsvFilepath))
                    {
                      var flightsCsv = new CsvReader(reader);
                      flightsCsv.Configuration.RegisterClassMap<FlightMap>();
                      var flights = flightsCsv.GetRecords<Flight>();
                      foreach(var flight in flights)
                      {
                        context.Flight.Add(flight);
                      }
                      context.SaveChanges();
                    }
                
                context.SaveChanges();
                }
                
            }
        }
    }
}
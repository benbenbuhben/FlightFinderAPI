using Microsoft.EntityFrameworkCore;

namespace FlightFinderAPI.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flight { get; set; }
        public DbSet<Airport> Airport { get; set; }
    }
}
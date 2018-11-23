using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Linq;
using FlightFinderAPI.Models;
using FlightFinderAPI.Controllers;
using Xunit;

namespace FlightFinderTests
{
  public class AirportsControllerTests
    {
    public AirportsControllerTests()
    {
    }

        [Fact]
        public void TestCanGetAllAirportsReturnsProperType()
        {
            DbContextOptions<FlightContext> options =
         new DbContextOptionsBuilder<FlightContext> ()
         .UseInMemoryDatabase("TestCanGetAllAirports")
         .Options;

            using (FlightContext context = new FlightContext(options))
            {

                AirportsController airports_controller = new AirportsController(context);

                var expected = typeof(List<Airport>);
                var actual = airports_controller.GetAll().Value;

                Assert.IsType<List<Airport>>(actual);
                Assert.IsType(expected, actual);
            }
        }

    }
}

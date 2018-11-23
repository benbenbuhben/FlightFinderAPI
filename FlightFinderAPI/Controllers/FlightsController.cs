using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Linq;
using FlightFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightFinderAPI.Controllers
{   
    [Route("api/[controller]")] 
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightContext _context;

        public FlightsController(FlightContext context) => _context = context;

        // TODO: Can we just handle invalid query params on client side? Yes, but we should still handle invalid raw url's. Is NotFound the appropriate status code?
        [HttpGet("search/{orderBy?}")]
        public ActionResult<List<Flight>> SortBySpecifiedParameter([FromQuery]string from, [FromQuery]string to)
        {   
            if(from == null || to == null){ return NotFound(); }
            
            var flights = from flight in _context.Flight select flight;

            return flights.Where(flight => flight.From == from).Where(flight => flight.To == to).ToList();  
        }

        [HttpGet("search")]
        public ActionResult<List<Flight>> GetByOriginAndDestination([FromQuery]string from, [FromQuery]string to)
        {   
            if(from == null || to == null){ return NotFound(); }
            
            var flights = from flight in _context.Flight select flight;

            return flights.Where(flight => flight.From == from).Where(flight => flight.To == to).ToList();  
        }
       
        [HttpGet("all", Name = "GetAllFlights")]
        public ActionResult<List<Flight>> GetAll() => _context.Flight.ToList();

    }
}
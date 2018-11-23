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
    public class AirportsController : ControllerBase
    {
        private readonly FlightContext _context;

        public AirportsController(FlightContext context) => _context = context;
 
        [HttpGet("all", Name = "GetAllAirports")]
        public ActionResult<List<Airport>> GetAll() => _context.Airport.ToList();

    }
}
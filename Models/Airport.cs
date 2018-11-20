using System;
using System.ComponentModel.DataAnnotations;

namespace FlightFinderAPI.Models
{
    public class Airport
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

}
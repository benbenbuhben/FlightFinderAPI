using System;
using CsvHelper.Configuration;

namespace FlightFinderAPI.Models
{
  public class Flight
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int FlightNumber { get; set; }
        public DateTime Departs { get; set; }
        public DateTime Arrives { get; set; }
        public int MainCabinPrice { get; set; }
        public int FirstClassPrice { get; set; }
    }

    public sealed class FlightMap : ClassMap<Flight>
    {
        public FlightMap()
        {
        AutoMap();
        Map(m => m.ID).Ignore();
        Map(m => m.MainCabinPrice).ConvertUsing(row => (int)row.GetField<float>("MainCabinPrice"));
        Map(m => m.FirstClassPrice).ConvertUsing(row => (int)row.GetField<float>("FirstClassPrice"));
        }
    }

}
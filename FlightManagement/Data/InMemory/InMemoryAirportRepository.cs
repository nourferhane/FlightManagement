using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data.InMemory
{
    public class InMemoryAirportRepository : IAirportRepository
    {
        List<Airport> Airports = new List<Airport>
        {
            new Airport{ Longitude = 40 , Latitude = 3 ,Name = "Paris" , Code = "A1"},
            new Airport{ Longitude = 10 , Latitude = 2 ,Name = "Casablanca" , Code = "A2"},

            new Airport{ Longitude = 15 , Latitude = 0 ,Name = "London" , Code = "A3"},

            new Airport{ Longitude = 17 , Latitude = 1 ,Name = "Safi" , Code = "A4"},

        };
        public IEnumerable<Airport> GetAll()
        {
            return Airports;
        }

        public Airport GetByCode(string code)
        {
            return Airports.FirstOrDefault(a => a.Code == code);
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Airport GetByName(string name)
        {
            return Airports.FirstOrDefault(a => a.Name == name);
        }

        /// <summary>
        /// Getbies the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Airport GetbyCode(string code)
        {
            return Airports.FirstOrDefault(a => a.Code == code);
        }

        /// <summary>
        /// Adds the specified airport.
        /// </summary>
        /// <param name="airport">The airport.</param>
        public void Add(Airport airport)
        {
            Airports.Add(airport);
        }
    }
}

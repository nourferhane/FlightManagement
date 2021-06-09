using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data.Sql
{

    public class SqlAirportRepository : IAirportRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly DataContext _context;

        public SqlAirportRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Airport> GetAirports()
        {
            return _context.Airports.ToList();
        }

        public Airport GetAirportbyName(string name)
        {
            return _context.Airports.FirstOrDefault(a => a.Name == name);
        }

        public Airport GetAirportbyCode(string code)
        {
            return _context.Airports.FirstOrDefault(a => a.Code == code);
        }

        public void AddAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
        }
    }
}

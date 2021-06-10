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

        public IEnumerable<Airport> GetAll()
        {
            return _context.Airports.ToList();
        }

        public void Add(Airport modelToAdd)
        {
            _context.Airports.Add(modelToAdd);
            _context.SaveChanges();
        }

        public Airport GetByCode(string code)
        {
            return _context.Airports.FirstOrDefault(a => a.Code == code);
        }

        public Airport GetByName(string name)
        {
            return _context.Airports.FirstOrDefault(a => a.Name == name);
        }
    }
}

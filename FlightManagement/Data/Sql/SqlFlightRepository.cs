using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data.Sql
{
    public class SqlFlightRepository : IFlightRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFlightRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SqlFlightRepository(DataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights.ToList();
        }

        /// <summary>
        /// Adds the specified model to add.
        /// </summary>
        /// <param name="modelToAdd">The model to add.</param>
        public void Add(Flight modelToAdd)
        {
            _context.Add(modelToAdd);
            _context.SaveChanges();
        }

        public Flight GetByCode(string code)
        {
            return _context.Flights.FirstOrDefault(f => f.Reference == code);
        }

        public Flight GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

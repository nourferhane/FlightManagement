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
        /// Initializes a new instance of the <see cref="IFlightRepository" /> interface.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void AddFlight(Flight flight)
        {
            _context.Add(flight);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        /// <summary>
        /// Gets the flight by reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        public Flight GetFlightByRef(string reference)
        {
            return _context.Flights.FirstOrDefault(f => f.Reference == reference);
        }
    }
}

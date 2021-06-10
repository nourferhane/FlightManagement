using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data.InMemory
{
    public class InMemoryFlightRepository : IFlightRepository
    {
        /// <summary>
        /// The flights
        /// </summary>
        List<Flight> Flights = new List<Flight>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IFlightRepository" /> interface.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }
        
        /// <summary>
        /// Gets the flight by reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Flight GetFlightByRef(string reference)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAll()
        {
            return Flights;
        }

        /// <summary>
        /// Adds the specified model to add.
        /// </summary>
        /// <param name="modelToAdd">The model to add.</param>
        public void Add(Flight modelToAdd)
        {
            Flights.Add(modelToAdd);
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Flight GetByCode(string code)
        {
            return Flights.FirstOrDefault(p => p.Reference == code);
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Flight GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

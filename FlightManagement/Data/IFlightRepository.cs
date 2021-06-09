using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data
{
    public interface IFlightRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IFlightRepository"/> interface.
        /// </summary>
        /// <param name="flight">The flight.</param>
        void AddFlight(Flight flight);

        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Flight> GetFlights();

        /// <summary>
        /// Gets the flight by reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        Flight GetFlightByRef(string reference);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Services.FlightService
{
    public interface IFlightService
    {
        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Flight> GetFlights();

        /// <summary>
        /// Adds the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <returns></returns>
        void AddFlight(Flight flight);

        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <returns></returns>
        Flight GetFlightByReference(string reference);

        /// <summary>
        /// Removes the specified reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        void Remove(string reference);

    }
}

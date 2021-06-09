using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data
{
    public interface IAirportRepository
    {
        /// <summary>
        /// Gets the airports.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airport> GetAirports();

        /// <summary>
        /// Gets the name of the airportby.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Airport GetAirportbyName(string name);

        /// <summary>
        /// Gets the airportby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Airport GetAirportbyCode(string code);

        /// <summary>
        /// Adds the airport.
        /// </summary>
        void AddAirport(Airport airport);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Services.AirportService
{
    public interface IAirportService
    {
        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Airport GetByCode(string code);
       
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airport> GetAll();

        /// <summary>
        /// Adds the airport.
        /// </summary>
        void AddAirport(Airport airport);

    }
}

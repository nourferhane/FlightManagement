using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Data;
using FlightManagement.Models;

namespace FlightManagement.Services.AirportService
{
    public class AirportService : IAirportService
    {
        /// <summary>
        /// The airport repository
        /// </summary>
        private readonly IAirportRepository _airportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportService"/> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository.</param>
        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Airport GetByCode(string code)
        {
            return _airportRepository.GetByCode(code);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Airport> GetAll()
        {
            return _airportRepository.GetAll();
        }

        /// <summary>
        /// Adds the airport.
        /// </summary>
        /// <param name="airport"></param>
        public void AddAirport(Airport airport)
        {
            _airportRepository.Add(airport);
        }

    }
}

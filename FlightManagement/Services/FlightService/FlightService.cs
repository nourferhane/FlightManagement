using FlightManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;
using FlightManagement.Services.GpsService;

namespace FlightManagement.Services.FlightService
{
    public class FlightService : IFlightService
    {
        /// <summary>
        /// The flights repository
        /// </summary>
        private readonly IFlightRepository _flightsRepository;

        /// <summary>
        /// The GPS service
        /// </summary>
        private readonly IGpsService _gpsService;

        public FlightService(IFlightRepository flightsRepository, IGpsService gpsService)
        {
            _flightsRepository = flightsRepository;
            _gpsService = gpsService;
        }
        /// <summary>
        /// Gets the flights.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlights()
        {
           return _flightsRepository.GetAll();
        }

        /// <summary>
        /// Adds the flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        public void AddFlight(Flight flight)
        {
            _flightsRepository.Add(flight);
        }

        public Flight GetFlightByReference(string reference)
        {
            return _flightsRepository.GetByCode(reference);
        }
    }
}

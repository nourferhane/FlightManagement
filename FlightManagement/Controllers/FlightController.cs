using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;
using FlightManagement.Services.AirplaneService;
using FlightManagement.Services.AirportService;
using FlightManagement.Services.FlightService;
using FlightManagement.Services.GpsService;

namespace FlightManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : Controller
    {
        /// <summary>
        /// The air plane service
        /// </summary>
        private IAirPlaneService _airPlaneService;

        /// <summary>
        /// The flight service
        /// </summary>
        private IFlightService _flightService;

        /// <summary>
        /// The airport service
        /// </summary>
        private IAirportService _airportService;

        /// <summary>
        /// The GPS service
        /// </summary>
        private readonly IGpsService _gpsService;

        public FlightController(IAirPlaneService airPlaneService, IFlightService flightService, IGpsService gpsService, IAirportService airportService)
        {
            _flightService = flightService;
            _airPlaneService = airPlaneService;
            _gpsService = gpsService;
            _airportService = airportService;

        }

        /// <summary>
        /// Gets the flight.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Flight> GetFlight()
        {
            return _flightService.GetFlights();
        }

        /// <summary>
        /// Adds the flight.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            if (flight == null) return BadRequest();
            var airportDepart = _airportService.GetByCode(flight.AeroportDepartCode);
            var airportDestination = _airportService.GetByCode(flight.AeroportDestinationCode);
            var airplane = _airPlaneService.GetByCode(flight.AirplaneCode);
            var distance = _gpsService.GetDistance(airportDepart.Latitude, airportDepart.Longitude,
                airportDestination.Latitude, airportDestination.Longitude);
            var travelTime = distance / airplane.MaxSpeed;
            var fuelAfterTakeOff = airplane.MaxFuel - airplane.MaxFuel * (airplane.TakeOffFuelConsumption / 100.0);
            var tripFuel = fuelAfterTakeOff - travelTime * airplane.ConsumptionPerHour;
           
            if (tripFuel <= 0)
            {
                return BadRequest("fuel not enough !!");
            }
            flight.Distance = distance;
            flight.ArrivalTime = flight.DepartureTime.Add(TimeSpan.FromHours(travelTime));
            _flightService.AddFlight(flight);
            return Ok();

        }

        /// <summary>
        /// Gets the flight.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Flight> GetFlightbyReference(string reference)
        {
            var flight = _flightService.GetFlightByReference(reference);
            if (flight is null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

    }
}

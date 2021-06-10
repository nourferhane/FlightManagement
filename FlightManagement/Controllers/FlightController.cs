using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Data;
using FlightManagement.Dtos;
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
        [Route("/Flights")]
        public IEnumerable<FlightDto> GetFlight()
        {
            List<FlightDto> flishtList = new List<FlightDto>();
            var flights = _flightService.GetFlights();
            foreach (var flight in flights)
            {
                flishtList.Add(FlightMapper(flight));
            }

            return flishtList;
        }

        /// <summary>
        /// Adds the flight.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            if (flight == null) return BadRequest();
            Airport airportDepart = _airportService.GetByCode(flight.AeroportDepartCode);
            Airport airportDestination = _airportService.GetByCode(flight.AeroportDestinationCode);
            Airplane airplane = _airPlaneService.GetByCode(flight.AirplaneCode);

            if (airplane == null || airportDestination == null || airportDepart == null)
            {
                return BadRequest();
            }


            if (string.Equals(airportDestination.Code, airportDepart.Code, StringComparison.CurrentCultureIgnoreCase))
            {
                return BadRequest();
            }

            double distance = _gpsService.GetDistance(airportDepart.Latitude, airportDepart.Longitude,
                airportDestination.Latitude, airportDestination.Longitude);
            var travelTime = distance / airplane.MaxSpeed;

            if (IsAirplaneFuelEnoughForTrip(airplane, distance, travelTime))
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
        [HttpGet("{reference}")]
        public IActionResult GetFlightbyReference(string reference)
        {
            var flight = _flightService.GetFlightByReference(reference);
            if (flight is null)
            {
                return NotFound();
            }
            var depart = _airportService.GetByCode(flight.AeroportDepartCode);
            var destination = _airportService.GetByCode(flight.AeroportDestinationCode);
           

            var dto = FlightMapper(flight);
            dto.AirportDepart = depart.Name;
            dto.AirportDestination = destination.Name;
            return Ok(dto);
        }

        /// <summary>
        /// Updates the flight.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult UpdateFlight(FlightDto dto)
        {
            // todo
            return Ok();
        }

        /// <summary>
        /// Deletes the flight.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        [HttpDelete("{reference}")]
        public IActionResult DeleteFlight(string reference)
        {
            var item = _flightService.GetFlightByReference(reference);
            if (item == null)
            {
                return NotFound();
            }
            _flightService.Remove(reference);
            return Ok();
        }



        /// <summary>
        /// Flights the mapper.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        private static FlightDto FlightMapper(Flight dto)
        {
            FlightDto tmp = new FlightDto
            {
                Reference = dto.Reference,
                Distance = dto.Distance,
                ArrivalTime = dto.ArrivalTime,
                AeroportDepartCode = dto.AeroportDepartCode,
                AeroportDestinationCode = dto.AeroportDestinationCode,
                DepartureTime = dto.DepartureTime,
                AirplaneCode = dto.AirplaneCode
            };

            return tmp;
        }

        private bool IsAirplaneFuelEnoughForTrip(Airplane airplane, double distance, double travelTime)
        {
            var fuelAfterTakeOff = airplane.MaxFuel - airplane.MaxFuel * (airplane.TakeOffFuelConsumption / 100.0);
            var tripFuel = fuelAfterTakeOff - travelTime * airplane.ConsumptionPerHour;

            return tripFuel > 0;
        }
    }
}

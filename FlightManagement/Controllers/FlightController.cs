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
        private IBaseRepository<Airplane> _airPlaneService;

        /// <summary>
        /// The flight service
        /// </summary>
        private IBaseRepository<Flight> _flightService;

        /// <summary>
        /// The airport service
        /// </summary>
        private IBaseRepository<Airport> _airportService;

        /// <summary>
        /// The GPS service
        /// </summary>
        private readonly IGpsService _gpsService;

        public FlightController(IBaseRepository<Airplane> airPlaneService, IBaseRepository<Flight> flightService, IGpsService gpsService, IBaseRepository<Airport> airportService)
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
            var flights = _flightService.GetAll();
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
            _flightService.Add(flight);
            return Ok();

        }

        /// <summary>
        /// Gets the flight.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{reference}")]
        public ActionResult<FlightDto> GetFlightbyReference(string reference)
        {
            var flight = _flightService.GetByCode(reference);
            var depart = _airportService.GetByCode(flight.AeroportDepartCode);
            var destination = _airportService.GetByCode(flight.AeroportDestinationCode);
            if (flight is null)
            {
                return NotFound();
            }

            var dto = FlightMapper(flight);
            dto.AirportDepart = depart.Name;
            dto.AirportDestination = destination.Name;
            return Ok(dto);
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

    }
}

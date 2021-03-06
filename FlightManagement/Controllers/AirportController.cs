using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Data;
using FlightManagement.Models;
using FlightManagement.Services.AirportService;
using Microsoft.AspNetCore.Cors;

namespace FlightManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : Controller
    {
        private readonly IBaseRepository<Airport> _airportService;

        public AirportController(IBaseRepository<Airport> airportService)
        {
            _airportService = airportService;
        }

        /// <summary>
        /// Gets the flight.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Airports")]
        public ActionResult<Airport> GetAirports()
        {
            var airports = _airportService.GetAll();
            if (airports is null)
            {
                return NotFound();
            }

            return Ok(airports);
        }

        /// <summary>
        /// Gets the airport by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public ActionResult<Airport> GetAirportByCode(string code)
        {
            var airport = _airportService.GetByCode(code);
            if (airport is null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        /// <summary>
        /// Adds the airport.
        /// </summary>
        /// <param name="airport">The airport.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddAirport(Airport airport)
        {
            if (airport is null)
            {
                return BadRequest();
            }
            _airportService.Add(airport);

            return Ok();
        }
    }
}

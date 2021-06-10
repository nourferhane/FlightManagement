using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Data;
using FlightManagement.Models;
using FlightManagement.Services.AirplaneService;

namespace FlightManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AirplaneController> _logger;

        /// <summary>
        /// The airplane service
        /// </summary>
        private readonly IBaseRepository<Airplane> _airplaneService;

        public AirplaneController(ILogger<AirplaneController> logger, IBaseRepository<Airplane> airplaneService)
        {
            _logger = logger;
            _airplaneService = airplaneService;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Airplanes")]
        public IEnumerable<Airplane> GetAllAirplanes()
        {
            return _airplaneService.GetAll();
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public Airplane GetByCode(string code)
        {
            return _airplaneService.GetByCode(code);
        }

        /// <summary>
        /// Adds the plane.
        /// </summary>
        /// <param name="airplane">The airplane.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPlane([FromBody]Airplane airplane)
        {
            if (airplane == null)
                return BadRequest();
            _airplaneService.Add(airplane);
           return Ok();
        }
    }
}

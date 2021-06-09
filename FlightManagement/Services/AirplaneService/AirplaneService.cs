using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Data;
using FlightManagement.Models;

namespace FlightManagement.Services.AirplaneService
{
    public class AirplaneService : IAirPlaneService
    {
        /// <summary>
        /// The airplane repository
        /// </summary>
        private readonly IAirplaneRepository _airplaneRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirplaneService"/> class.
        /// </summary>
        /// <param name="airplaneRepository">The airplane repository.</param>
        public AirplaneService(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }

        /// <summary>
        /// Gets the planes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Airplane> GetPlanes()
        {
            return _airplaneRepository.GetPlanes();
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Airplane GetByName(string name)
        {
            return _airplaneRepository.GetByName(name);
        }

        /// <summary>
        /// Adds the specified airplane.
        /// </summary>
        /// <param name="airplane">The airplane.</param>
        public void Add(Airplane airplane)
        {
            _airplaneRepository.Add(airplane);
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Airplane GetByCode(string code)
        {
            return _airplaneRepository.GetByCode(code);
        }
    }
}

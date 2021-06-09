using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Services.AirplaneService
{
    public interface IAirPlaneService
    {
        /// <summary>
        /// Gets the planes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airplane> GetPlanes();

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Airplane GetByName(string name);
        
        /// <summary>
        /// Adds the specified airplane.
        /// </summary>
        /// <param name="airplane">The airplane.</param>
        void Add(Airplane airplane);

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Airplane GetByCode(string code);
    }
}

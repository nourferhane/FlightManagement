using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data.InMemory
{
    public class InMemoryAirplaneRepository : IAirplaneRepository
    {
        /// <summary>
        /// The airplanes
        /// </summary>
        List<Airplane> Airplanes = new List<Airplane>
        {
            new Airplane{ ConsumptionPerHour = 150, MaxSpeed =  300 , Name =  "Alpha" , MaxFuel =  3000, TakeOffFuelConsumption = 15 , Brand = "Boeing", Code = "AB1"},
            new Airplane{ ConsumptionPerHour = 145, MaxSpeed =  250 , Name =  "Beta" , MaxFuel =  400, TakeOffFuelConsumption = 10 , Brand = "Boeing", Code = "AB2"},
            new Airplane{ ConsumptionPerHour = 200, MaxSpeed =  400 , Name =  "Teta" , MaxFuel =  3570, TakeOffFuelConsumption = 14 , Brand = "Airbus", Code = "AB3"},
            new Airplane{ ConsumptionPerHour = 200, MaxSpeed =  360 , Name =  "Neta" , MaxFuel =  2000, TakeOffFuelConsumption = 13 , Brand = "Airbus", Code = "AB4"},
        };

        /// <summary>
        /// Gets the planes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Airplane> GetAll()
        {
            return Airplanes;
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Airplane GetByName(string name)
        {
            return Airplanes.FirstOrDefault(a => a.Name == name);
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Airplane GetByCode(string code)
        {
            return Airplanes.FirstOrDefault(a => a.Code == code);
        }

        /// <summary>
        /// Adds the specified airplane.
        /// </summary>
        /// <param name="airplane">The airplane.</param>
        public void Add(Airplane airplane)
        {
            Airplanes.Add(airplane);
        }
    }
}

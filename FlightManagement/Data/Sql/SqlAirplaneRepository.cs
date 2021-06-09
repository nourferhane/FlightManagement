using System;
using System.Collections.Generic;
using System.Linq;
using FlightManagement.Models;

namespace FlightManagement.Data.Sql
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FlightManagement.Data.IAirplaneRepository" />
    public class SqlAirplaneRepository : IAirplaneRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly DataContext _context;

        public SqlAirplaneRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets the planes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Airplane> GetPlanes()
        {
            return _context.Planes.ToList();
        }


        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Airplane GetByName(string name)
        {
            return _context.Planes.FirstOrDefault(a => a.Name == name);
        }

        public Airplane GetByCode(string code)
        {
           return  _context.Planes.FirstOrDefault(a => a.Code == code);
        }

        /// <summary>
        /// Adds the specified airplane.
        /// </summary>
        /// <param name="airplane">The airplane.</param>
        public void Add(Airplane airplane)
        {
            _context.Add(airplane);
            _context.SaveChanges();
        }
    }
}

using FlightManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Data
{
    /// <summary>
    /// The hero context class.
    /// </summary>
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
                
        }

        public DbSet<Airplane> Planes { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }


    }
}

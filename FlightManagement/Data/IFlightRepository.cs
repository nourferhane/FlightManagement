using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Models;

namespace FlightManagement.Data
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        //Flight GetFlightByRef(string reference);
    }
}

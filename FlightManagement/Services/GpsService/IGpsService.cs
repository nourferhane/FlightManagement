using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Services.GpsService
{
    public interface IGpsService
    {
        /// <summary>
        /// Gets the distance.
        /// </summary>
        /// <param name="sourceLatitude">The source latitude.</param>
        /// <param name="sourceLongitude">The source longitude.</param>
        /// <param name="destinationLatitude">The destination latitude.</param>
        /// <param name="destinationLongitude">The destination longitude.</param>
        /// <returns></returns>
        double GetDistance(long sourceLatitude, long sourceLongitude, long destinationLatitude,
            long destinationLongitude);
    }
}

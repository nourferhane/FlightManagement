using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace FlightManagement.Services.GpsService
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FlightManagement.Services.GpsService.IGpsService" />
    public class GpsService : IGpsService
    {
        /// <summary>
        /// Gets the distance.
        /// </summary>
        /// <param name="sourceLatitude">The source latitude.</param>
        /// <param name="sourceLongitude">The source longitude.</param>
        /// <param name="destinationLatitude">The destination latitude.</param>
        /// <param name="destinationLongitude">The destination longitude.</param>
        /// <returns></returns>
        public double GetDistance(long sourceLatitude, long sourceLongitude, long destinationLatitude, long destinationLongitude)
        {
            var originCoordinates = new GeoCoordinate(sourceLatitude, sourceLongitude);
            var destinationCoordinates = new GeoCoordinate(destinationLatitude, destinationLongitude);
            var distance = originCoordinates.GetDistanceTo(destinationCoordinates);
            return Math.Round(distance/1000,2);
        }
    }
}

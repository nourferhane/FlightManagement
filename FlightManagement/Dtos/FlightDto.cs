using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Dtos
{
    public class FlightDto
    {
        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets the airport depart.
        /// </summary>
        /// <value>
        /// The airport depart.
        /// </value>
        public string AirportDepart { get; set; }

        /// <summary>
        /// Gets or sets the aeroport destination.
        /// </summary>
        /// <value>
        /// The aeroport destination.
        /// </value>
        public string AirportDestination { get; set; }

        /// <summary>
        /// Gets or sets the aeroport depart code.
        /// </summary>
        /// <value>
        /// The aeroport depart code.
        /// </value>
        public string AeroportDepartCode { get; set; }

        /// <summary>
        /// Gets or sets the aeroport destination code.
        /// </summary>
        /// <value>
        /// The aeroport destination code.
        /// </value>
        public string AeroportDestinationCode { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        /// <value>
        /// The departure time.
        /// </value>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        /// <value>
        /// The arrival time.
        /// </value>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public Double Distance { get; set; }


        /// <summary>
        /// Gets or sets the airplane code.
        /// </summary>
        /// <value>
        /// The airplane code.
        /// </value>
        public string AirplaneCode { get; set; }
    }
}

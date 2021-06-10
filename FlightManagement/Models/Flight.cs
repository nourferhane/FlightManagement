using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightManagement.Models
{
    public class Flight
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the aeroport source.
        /// </summary>
        /// <value>
        /// The aeroport source.
        /// </value>
        [ForeignKey("AeroportDepartCode")]
        [JsonIgnore]
        public Airport AeroportDepart { get; set; }

        /// <summary>
        /// Gets or sets the aeroport destination.
        /// </summary>
        /// <value>
        /// The aeroport destination.
        /// </value>
        [ForeignKey("AeroportDestinationCode")]
        [JsonIgnore]
        public Airport AeroportDestination { get; set; }

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
        [JsonIgnore]
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        [JsonIgnore]
        public Double Distance { get; set; }

        /// <summary>
        /// Gets or sets the airplane.
        /// </summary>
        /// <value>
        /// The airplane.
        /// </value>
        [ForeignKey("AirplaneCode")]
        [JsonIgnore]
        public Airplane Airplane { get; set; }

        /// <summary>
        /// Gets or sets the airplane code.
        /// </summary>
        /// <value>
        /// The airplane code.
        /// </value>
        public string AirplaneCode { get; set; }
    }
}

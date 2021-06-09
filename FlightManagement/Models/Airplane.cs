
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightManagement.Models
{
    /// <summary>
    /// The Airplane Class.
    /// </summary>
    public class Airplane
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [Key]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the airplane.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        /// <value>
        /// The brand.
        /// </value>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the maximum fuel.
        /// </summary>
        /// <value>
        /// The maximum fuel.
        /// </value>
        public int MaxFuel { get; set; }

        /// <summary>
        /// Gets or sets the take off fuel consumption.
        /// </summary>
        /// <value>
        /// The take off fuel consumption.
        /// </value>
        [Range(0,100)]
        public uint TakeOffFuelConsumption { get; set; }

        /// <summary>
        /// Gets or sets the maximum speed.
        /// </summary>
        /// <value>
        /// The maximum speed.
        /// </value>
        [Range(0,500)]
        public int MaxSpeed { get; set; }

        /// <summary>
        /// Gets or sets the consumption onhight speed.
        /// </summary>
        /// <value>
        /// The consumption onhight speed.
        /// </value>
        public int ConsumptionPerHour{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Controllers;
using FlightManagement.Data;
using FlightManagement.Models;
using FlightManagement.Services.AirplaneService;
using FlightManagement.Services.AirportService;
using FlightManagement.Services.FlightService;
using FlightManagement.Services.GpsService;
using Moq;

namespace Test.Units
{
    public class BaseTest
    {
        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected Mock<IFlightService> _mockedFlightService;

        /// <summary>
        /// The mocked airplane repository
        /// </summary>
        protected Mock<IBaseRepository<Airplane>> _mockedAirplaneRepository;

        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected Mock<IBaseRepository<Flight>> _mockedFlightRepository;

        /// <summary>
        /// The mocked airport repository
        /// </summary>
        protected Mock<IBaseRepository<Airport>> _mockedAirportRepository;

        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected Mock<IAirportService> _mockedAirportService;

        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected Mock<IAirPlaneService> _mockedAirplaneService;

        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected Mock<IGpsService> _mockedGpsService;


        /// <summary>
        /// The mocked flight repository
        /// </summary>
        protected FlightController _flightController;

        public BaseTest()
        {
            _mockedFlightService = new Mock<IFlightService>();

            _mockedAirportService = new Mock<IAirportService>();

            _mockedAirplaneService = new Mock<IAirPlaneService>();

            _mockedGpsService= new Mock<IGpsService>();

            _mockedAirplaneRepository = new Mock<IBaseRepository<Airplane>>();

            _mockedFlightRepository= new Mock<IBaseRepository<Flight>>();

            _mockedAirportRepository=new Mock<IBaseRepository<Airport>>();

            _flightController = new FlightController(_mockedAirplaneService.Object, _mockedFlightService.Object, _mockedGpsService.Object, _mockedAirportService.Object);
        }
    }
}

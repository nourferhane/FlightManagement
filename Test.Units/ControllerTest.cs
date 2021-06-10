using System;
using FlightManagement.Data;
using FlightManagement.Dtos;
using FlightManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Test.Units
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Test.Units.BaseTest" />
    public class ControllerTest : BaseTest
    {
        /// <summary>
        /// Creats the flight when valid request returns ok.
        /// </summary>
        [Fact]
        public void CreatFlight_WhenValidRequest_ReturnsOK()
        {
           // Arrange
           Flight flight = new Flight{Reference = "A" , Distance =  100 ,DepartureTime = DateTime.Now , ArrivalTime =  DateTime.Now.AddHours(2) };
           _mockedGpsService
               .Setup(x => x.GetDistance(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>()))
               .Returns(200);

           _mockedAirportService.Setup(a => a.GetByCode(It.IsAny<string>())).Returns(new Airport
               {Longitude = 1, Name = "A", Code = "Code", Latitude = 0});

           _mockedAirplaneService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(new Airplane
               {Name = "test", ConsumptionPerHour = 10, MaxSpeed = 200, Code = "Code", MaxFuel = 1000});


            //Act
            var result =_flightController.AddFlight(flight);

           //Assert
           Assert.IsType<OkResult>(result);
        }

        /// <summary>
        /// Creats the flight when fuel not enough fot the trip returns bad request.
        /// </summary>
        [Fact]
        public void CreatFlight_WhenFuelNotEnoughFotTheTrip_ReturnsBadRequest()
        {
            // Arrange
            Flight flight = new Flight { Reference = "A", Distance = 100, DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2) };
            _mockedGpsService
                .Setup(x => x.GetDistance(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(500);

            _mockedAirportService.Setup(a => a.GetByCode(It.IsAny<string>())).Returns(new Airport
                { Longitude = 1, Name = "A", Code = "Code", Latitude = 0 });

            _mockedAirplaneService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(new Airplane
                { Name = "test", ConsumptionPerHour = 300, MaxSpeed = 200, Code = "Code", MaxFuel = 500 });


            //Act
            var result = _flightController.AddFlight(flight);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Creats the flight when airport data not found returns bad request.
        /// </summary>
        [Fact]
        public void CreatFlight_WhenAirportDataNotFound_ReturnsBadRequest()
        {
            // Arrange
            Flight flight = new Flight { Reference = "A", Distance = 100, DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2) };
            _mockedGpsService
                .Setup(x => x.GetDistance(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(500);
            
            _mockedAirplaneService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(new Airplane
                { Name = "test", ConsumptionPerHour = 300, MaxSpeed = 200, Code = "Code", MaxFuel = 500 });


            //Act
            var result = _flightController.AddFlight(flight);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Creats the flight when airplane data not found returns bad request.
        /// </summary>
        [Fact]
        public void CreatFlight_WhenAirplaneDataNotFound_ReturnsBadRequest()
        {
            // Arrange
            Flight flight = new Flight { Reference = "A", Distance = 100, DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2) };
            _mockedGpsService
                .Setup(x => x.GetDistance(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>(), It.IsAny<long>()))
                .Returns(500);

            _mockedAirplaneService.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(new Airplane
                { Name = "test", ConsumptionPerHour = 300, MaxSpeed = 200, Code = "Code", MaxFuel = 500 });


            //Act
            var result = _flightController.AddFlight(flight);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Gets the flight when flight not exist returns not found.
        /// </summary>
        [Fact]
        public void GetFlight_WhenFlightNotExist_ReturnsNotFound()
        {
            // Arrange
            _mockedAirportService.Setup(a => a.GetByCode(It.IsAny<string>())).Returns(new Airport
                { Longitude = 1, Name = "A", Code = "Code", Latitude = 0 });

            //Act
            var result = _flightController.GetFlightbyReference("AAA");

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Shared.Logger.ProviderContracts;
using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using NewShoreAirApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NewShoreApiTest.Mocks;
using Moq;
using Domain.Journey;

namespace NewShoreApiTest.NewShoreAirApi.Controllers
{
    [TestClass]
    public class FlightControllerTest
    {
        private readonly Mock<IGetFlightRutesUseCase> mockGetFlightRutesUseCase;
        private readonly Mock<IGetJourneyByRuteUseCase> mocketJourneyByRuteUseCase;
        private readonly Mock<IFlightProvier> IFlightProvier;
        private readonly Mock<ILoggerProviderContract> mockLoggerProvider;

        private RouteDtoMock routeDtoMock;
        private JourneyMock journeyMock;

        public FlightControllerTest()
        {
            this.mockGetFlightRutesUseCase = new Mock<IGetFlightRutesUseCase>();
            this.mocketJourneyByRuteUseCase = new Mock<IGetJourneyByRuteUseCase>();
            this.IFlightProvier = new Mock<IFlightProvier>();
            this.mockLoggerProvider = new Mock<ILoggerProviderContract>();

            this.routeDtoMock = new RouteDtoMock();
            this.journeyMock = new JourneyMock();
        }

        [TestMethod]
        public void ReturnOkListToLightsRoutes()
        {
            List<RouteDto> routes = new List<RouteDto>
            {
                this.routeDtoMock.WhithOrigin().WhithDestination().Build()
            };

            this.mockGetFlightRutesUseCase.Setup(func => func.Execute()).Returns(routes);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                                this.mocketJourneyByRuteUseCase.Object,
                                                this.mockLoggerProvider.Object);

            var response = controller.GetFligthRoutesUseCase() as ObjectResult;

            Assert.AreEqual(200, response?.StatusCode);
        }

        [TestMethod]
        public void ReturnNullTolightsRoutes()
        {
            List<RouteDto> routes = new List<RouteDto>();

            this.mockGetFlightRutesUseCase.Setup(func => func.Execute()).Returns(routes);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                    this.mocketJourneyByRuteUseCase.Object,
                                    this.mockLoggerProvider.Object);

            var response = controller.GetFligthRoutesUseCase() as ObjectResult;

            Assert.IsNull(response);
        }

        [TestMethod]
        public void ReturnOkJourneyByRoute()
        {
            RouteDto route = this.routeDtoMock.WhithOrigin().WhithDestination().Build();

            Journey journey = this.journeyMock.Build();

            this.mocketJourneyByRuteUseCase.Setup(func => func.Execute(route)).Returns(journey);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                                this.mocketJourneyByRuteUseCase.Object,
                                                this.mockLoggerProvider.Object);

            var response = controller.GetJourneyByRoute(route) as ObjectResult;

            Assert.AreEqual(200, response?.StatusCode);
        }

        [TestMethod]
        public void ReturnNullJourneyByRoute()
        {
            RouteDto route = this.routeDtoMock.WhithOrigin().WhithDestination().Build();

            Journey journey = null;

            this.mocketJourneyByRuteUseCase.Setup(func => func.Execute(route)).Returns(journey);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                    this.mocketJourneyByRuteUseCase.Object,
                                    this.mockLoggerProvider.Object);

            var response = controller.GetJourneyByRoute(route) as ObjectResult;

            Assert.IsNull(response);
        }
    }
}
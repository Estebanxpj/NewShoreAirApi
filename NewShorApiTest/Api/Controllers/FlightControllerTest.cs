using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using Application.Shared.Logger.ProviderContracts;
using Domain.Journey;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewShorApiTest.Mocks;
using NewShoreAirApi.Controllers;

namespace NewShorApiTest.Api.Controllers
{
    [TestClass]
    public class FlightControllerTest
    {
        private readonly Mock<IGetFlightRutesUseCase> mockGetFlightRutesUseCase;
        private readonly Mock<IGetJourneyByRuteUseCase> mocketJourneyByRuteUseCase;
        private readonly Mock<ILoggerProviderContract> mockLoggerProvider;

        private RouteDtoMock routeDtoMock;
        private JourneyMock journeyMock;

        public FlightControllerTest()
        {
            this.mockGetFlightRutesUseCase = new Mock<IGetFlightRutesUseCase>();
            this.mocketJourneyByRuteUseCase = new Mock<IGetJourneyByRuteUseCase>();
            this.mockLoggerProvider = new Mock<ILoggerProviderContract>();

            this.routeDtoMock = new RouteDtoMock();
            this.journeyMock = new JourneyMock();
        }

        [TestMethod]
        public async Task ReturnOkListToLightsRoutes()
        {
            List<RouteDto> routes = new List<RouteDto>
            {
                this.routeDtoMock.WhithOrigin().WhithDestination().Build()
            };

            this.mockGetFlightRutesUseCase.Setup(func => func.Execute()).ReturnsAsync(routes);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                                this.mocketJourneyByRuteUseCase.Object,
                                                this.mockLoggerProvider.Object);

            var response = await controller.GetFligthRoutesUseCase() as ObjectResult;

            Assert.AreEqual(200, response?.StatusCode);
        }

        [TestMethod]
        public async Task ReturnNullTolightsRoutes()
        {
            List<RouteDto> routes = new List<RouteDto>();

            this.mockGetFlightRutesUseCase.Setup(func => func.Execute()).ReturnsAsync(routes);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                    this.mocketJourneyByRuteUseCase.Object,
                                    this.mockLoggerProvider.Object);

            var response = await controller.GetFligthRoutesUseCase() as ObjectResult;

            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task ReturnOkJourneyByRoute()
        {
            RouteDto route = this.routeDtoMock.WhithOrigin().WhithDestination().Build();

            Journey journey = this.journeyMock.WhithFlights().Build();

            this.mocketJourneyByRuteUseCase.Setup(func => func.Execute(route)).ReturnsAsync(journey);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                                this.mocketJourneyByRuteUseCase.Object,
                                                this.mockLoggerProvider.Object);

            var response = await controller.GetJourneyByRoute(route) as ObjectResult;

            Assert.AreEqual(200, response?.StatusCode);
        }

        [TestMethod]
        public async Task ReturnNullJourneyByRoute()
        {
            RouteDto route = this.routeDtoMock.WhithOrigin().WhithDestination().Build();

            Journey journey = null;

            this.mocketJourneyByRuteUseCase.Setup(func => func.Execute(route)).ReturnsAsync(journey);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                    this.mocketJourneyByRuteUseCase.Object,
                                    this.mockLoggerProvider.Object);

            var response = await controller.GetJourneyByRoute(route) as ObjectResult;

            Assert.IsNull(response);
        }
    }
}
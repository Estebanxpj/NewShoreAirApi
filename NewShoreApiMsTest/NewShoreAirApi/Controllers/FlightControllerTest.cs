using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using Application.Shared.Logger.ProviderContracts;
using Domain.Journey;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewShoreAirApi.Controllers;
using NewShoreApiMsTest.Mocks;

namespace NewShoreApiMsTest.NewShoreAirApi.Controllers
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
        public async void ReturnOkListToLightsRoutes()
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
        public async void ReturnNullTolightsRoutes()
        {
            List<RouteDto> routes = null;

            this.mockGetFlightRutesUseCase.Setup(func => func.Execute()).ReturnsAsync(routes);

            var controller = new FlightController(this.mockGetFlightRutesUseCase.Object,
                                    this.mocketJourneyByRuteUseCase.Object,
                                    this.mockLoggerProvider.Object);

            var response = await controller.GetFligthRoutesUseCase() as ObjectResult;

            Assert.IsNull(response);
        }

        [TestMethod]
        public async void ReturnOkJourneyByRoute()
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
        public async void ReturnNullJourneyByRoute()
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
using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Journey;
using Application.Shared.Logger.ProviderContracts;

namespace NewShoreAirApi.Controllers
{

    [ApiController]
    public class FlightController : ControllerBase
    {

        private readonly ILoggerProviderContract loggerPtovier;
        private readonly IGetJourneyByRuteUseCase journeyUseCase;
        private readonly IGetFlightRutesUseCase getFligthRutesUseCase;

        public FlightController(IGetFlightRutesUseCase getFligthRutesUseCase,
            IGetJourneyByRuteUseCase journeyUseCase, ILoggerProviderContract loggerPtovier)
        {
            this.loggerPtovier = loggerPtovier;
            this.journeyUseCase = journeyUseCase;
            this.getFligthRutesUseCase = getFligthRutesUseCase;
        }

        [HttpPost("v1/flights/journey")]
        public async Task<ActionResult> GetJourneyByRoute(RouteDto routeDto)
        {
            Journey journey = await this.journeyUseCase.Execute(routeDto);

            if (journey == null) return NotFound();

            return Ok(journey);
        }

        [HttpGet("v1/flights")]
        public async Task<ActionResult> GetFligthRoutesUseCase()
        {
            List<RouteDto> routes = await this.getFligthRutesUseCase.Execute();

            if (!routes.Any()) return NotFound();

            return Ok(routes);
        }
    }
}
using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using Application.Shared.Logger.ProviderContracts;
using Application.Shared.UseCase;
using Domain.Flight;

namespace Application.Modules.Flights.UseCases
{
    public class GetFlightRoutesUseCase : BaseUseCase, IGetFlightRutesUseCase
    {
        private IFlightProvier flightsProvier;
        public GetFlightRoutesUseCase(IFlightProvier flightsProvier, ILoggerProviderContract logger) 
            : base(typeof(GetFlightRoutesUseCase).Name, logger)
        {
            this.flightsProvier = flightsProvier;
        }

        public async Task<List<RouteDto>> Execute()
        {
            try
            {
                List<Flight> flights = await this.flightsProvier.GetAllFligths();

                if (!flights.Any()) return null;

                List<RouteDto> routes = flights.Select(flight => {
                    return RouteDto.getRouteByFlight(flight);
                    }).ToList();

                return routes;

            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return null;
            }
        }
    }
}

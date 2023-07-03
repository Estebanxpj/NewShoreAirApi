using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.Dtos;
using Application.Shared.Logger.ProviderContracts;
using Application.Shared.UseCase;
using Domain.Flight;
using Domain.Journey;

namespace Application.Modules.Flights.UseCases
{
    public class GetJourneyByRouteUseCase : BaseUseCase, IGetJourneyByRuteUseCase
    {
        private IFlightProvier flightsProvier;
        public GetJourneyByRouteUseCase(IFlightProvier flightsProvier, ILoggerProviderContract logger)
            : base(typeof(GetJourneyByRouteUseCase).Name, logger)
        {
            this.flightsProvier = flightsProvier;
        }

        public async Task<Journey> Execute(RouteDto routeDto)
        {
            try
            {
                if (!IsValidRequest(routeDto)) return null;
                
                List<Flight> flights = await flightsProvier.GetAllFligths();

                if(!flights.Any()) return null;

                Journey journey = CalculateRoute(flights, routeDto);

                if (journey.flights.Any()) return journey;
                
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
            }
            return null;
        }

        private bool IsValidRequest(RouteDto route)
        {
            if (string.IsNullOrEmpty(route.origin) || string.IsNullOrEmpty(route.destination))
            {
                return false;
            }

            return true;
        }

        private Journey CalculateRoute(List<Flight> flights, RouteDto route)
        {
            Journey journey = new Journey(route.origin, route.destination);

            List<Flight> flightsResult = Flight.getFlightsByRoute(flights, route.origin, route.destination);

            if (flightsResult.Any())
            {
                journey.setFlightList(flightsResult.Take(1).ToList());
                return journey;
            }

            List<Flight> flightsOrigin = Flight.getFlightsByOrigin(flights, route.origin);
            List<Flight> flightsDestination = Flight.getFlightsByDestination(flights, route.destination);

            if (!flightsOrigin.Any() || !flightsDestination.Any()) return journey;

            foreach (var flightOrigin in flightsOrigin)
            {
                foreach (var flightDestination in flightsDestination) 
                {
                    List<Flight> flightsRout = Flight.getFlightsByRoute(flightsDestination,
                                        flightOrigin.destination,
                                        route.destination);

                    if (flightsRout.Any())
                    {
                        flightsResult.Add(flightOrigin);
                        flightsResult.Add(flightDestination);

                        journey.setFlightList(flightsResult);

                        return journey;
                    }
                }
            }
            return journey;
        }
    }
}

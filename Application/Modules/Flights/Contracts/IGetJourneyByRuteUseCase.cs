
using Application.Modules.Flights.Dtos;
using Domain.Journey;

namespace Application.Modules.Flights.Contracts
{
    public interface IGetJourneyByRuteUseCase
    {
        public Task<Journey> Execute(RouteDto routeDto);
    }
}

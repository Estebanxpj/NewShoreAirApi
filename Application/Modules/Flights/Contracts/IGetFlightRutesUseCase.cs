using Application.Modules.Flights.Dtos;

namespace Application.Modules.Flights.Contracts
{
    public interface IGetFlightRutesUseCase
    {
        public Task<List<RouteDto>> Execute();
    }
}

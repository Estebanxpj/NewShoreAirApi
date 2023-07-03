using Domain.Flight;

namespace Application.Modules.Flights.Contracts
{
    public interface IFlightProvier
    {
        public Task<List<Flight>> GetAllFligths();
    }
}

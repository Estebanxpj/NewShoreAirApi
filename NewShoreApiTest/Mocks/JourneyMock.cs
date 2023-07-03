using Application.Modules.Flights.Dtos;
using NewShoreApiTest.Mocks.Contracts;
using Domain.Journey;
using Domain.Flight;
using Domain.Transport;

namespace NewShoreApiTest.Mocks
{
    public class JourneyMock : IEntityBuilder<Journey>
    {
        private Journey journey;
        public JourneyMock(List<Flight> flights = null, string origin = "MDE", string destination = "BOG")
        {
            this.initialize(origin, destination, flights);
        }

        private void initialize(string origin, string destination, List<Flight> flights)
        {
            if (flights == null)
            {
                flights = new List<Flight>
                {
                    new Flight(origin, destination, 200 ,new Transport("", ""))
                };
            }

            this.journey = new Journey(origin, destination, flights);
        }

        public Journey Reset()
        {
            this.journey = new Journey("", "", null);

            return this.journey;
        }

        public Journey Build()
        {
            return this.journey;
        }
    }
}

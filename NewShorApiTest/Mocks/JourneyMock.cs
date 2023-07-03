using Domain.Flight;
using Domain.Journey;
using Domain.Transport;
using NewShorApiTest.Mocks.Contracts;

namespace NewShorApiTest.Mocks
{
    public class JourneyMock : IEntityBuilder<Journey>
    {
        private Journey journey;
        public JourneyMock(string origin = "MDE", string destination = "BOG")
        {
            this.initialize(origin, destination);
        }

        private void initialize(string origin, string destination)
        {
            this.journey = new Journey(origin, destination);
        }

        public Journey Reset()
        {
            this.journey = new Journey("", "");

            return this.journey;
        }

        public Journey Build()
        {
            return this.journey;
        }

        public JourneyMock WhithFlights(string origin = "MDE",
            string destination = "BOG",
            List<Flight> flights = null)
        {
            if (flights == null)
            {
                flights = new List<Flight>
                {
                    new Flight(origin, destination, 200 ,new Transport("", ""))
                };
            }

            this.journey.setFlightList(flights);

            return this;
        }
    }
}

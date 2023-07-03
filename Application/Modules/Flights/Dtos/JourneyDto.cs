using Domain.Flight;

namespace Application.Modules.Flights.Dtos
{
    public class JourneyDto
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public decimal price { get; set; }
        public List<Flight> Flights { get; set; }
    }
}

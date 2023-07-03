namespace Domain.Journey
{
    using Domain.Flight;
    using Domain.Route;
    public class Journey : Route
    {
        public List<Flight> flights { get; set;  }

        public Journey(string origin, string destination) : base(origin, destination)
        {
            flights = new List<Flight>();
        }

        public void calculatePrice()
        {
            if (this.flights.Count == 0) return;

            this.flights.ForEach(flight => this.price += flight.price);
        }

        public void setFlightList(List<Flight> flights)
        {
            this.flights = flights;
            this.calculatePrice();
        }
    }
}

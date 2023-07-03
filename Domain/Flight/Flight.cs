namespace Domain.Flight
{
    using Domain.Route;
    using Domain.Transport;
    public class Flight : Route
    {
        public Transport transport { get; }

        public Flight(string origin, string destination, decimal price, Transport transport) : base(origin, destination, price)
        {
            this.transport = transport;
        }

        public static List<Flight> getFlightsByRoute(List<Flight> flights, string origin, string destination)
        {
            List<Flight> flightResult = new List<Flight>();

            flightResult = flights.Where(flight => flight.origin == origin
                             && flight.destination == destination).ToList();

            return flightResult;

        }

        public static List<Flight> getFlightsByOrigin(List<Flight> flights, string origin)
        {
            List<Flight> flightResult = new List<Flight>();

            flightResult = flights.Where(flight => flight.origin == origin).ToList();

            return flightResult;

        }

        public static List<Flight> getFlightsByDestination(List<Flight> flights, string destination)
        {
            List<Flight> flightResult = new List<Flight>();

            flightResult = flights.Where(flight => flight.destination == destination).ToList();

            return flightResult;

        }
    }
}

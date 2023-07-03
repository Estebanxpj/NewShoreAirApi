using Adapters.Providers.Models;
using Domain.Transport;
using Domain.Flight;

namespace Adapters.Providers.NewShoreAir
{
    public class FlightMap
    {
        public static List<Flight> MapToDomain(List<FlightResponse> flightsResponse)
        {
            if (flightsResponse.Count == 0) return new List<Flight>();

            List<Flight> flights = flightsResponse.Select(flight =>
            {
                return new Flight(
                                flight.DepartureStation,
                                flight.ArrivalStation,
                                flight.Price,
                                new Transport(
                                            flight.FlightCarrier,
                                            flight.FlightNumber));
            }).ToList();

            return flights;
        }
    }
}

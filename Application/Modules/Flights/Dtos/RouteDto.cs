using Application.Modules.Flights.UseCases;
using Domain.Flight;

namespace Application.Modules.Flights.Dtos
{
    public class RouteDto
    {
        public string origin { get; set; }

        public string destination { get; set; }

        public static RouteDto getRouteByFlight(Flight flight)
        {
            RouteDto route = new RouteDto();
            route.origin = flight.origin;
            route.destination = flight.destination; 

            return route;
         
        }
    }
}

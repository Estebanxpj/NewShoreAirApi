using Application.Modules.Flights.Dtos;
using NewShoreApiTest.Mocks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreApiTest.Mocks
{
    public class RouteDtoMock : IEntityBuilder<RouteDto>
    {
        private RouteDto routeDto;
        public RouteDtoMock() { }

        public RouteDto Reset() 
        { 
            this.routeDto = new RouteDto();

            return this.routeDto;
        }

        public RouteDto Build()
        {
            return this.routeDto;
        }

        public RouteDtoMock WhithOrigin(string origin = "MDE")
        {
            this.routeDto.origin = origin;

            return this;
        }

        public RouteDtoMock WhithDestination(string destination = "BOG")
        {
            this.routeDto.destination = destination;

            return this;
        }
    }
}

﻿using Application.Modules.Flights.Dtos;
using NewShorApiTest.Mocks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShorApiTest.Mocks
{
    public class RouteDtoMock : IEntityBuilder<RouteDto>
    {
        private RouteDto routeDto;
        public RouteDtoMock()
        {
            this.routeDto = new RouteDto();
        }

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

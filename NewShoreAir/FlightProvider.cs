using Application.Modules.Flights.Contracts;
using Adapters.Providers.Models;
using Domain.Flight;
using Newtonsoft.Json;
using RestSharp;

namespace Adapters.Providers.NewShoreAir
{
    public class FlightProvider: IFlightProvier
    {
        private string fligthUrl = "https://recruiting-api.newshore.es/api/flights";
        private string level = "0";

        public async Task<List<Flight>> GetAllFligths()
        {
            List<Flight> flights = new List<Flight>();

            var client = new RestClient($"{fligthUrl}/{level}");
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK
                && response.Content != null)
            {
                List<FlightResponse> flightsResponse = JsonConvert.DeserializeObject<List<FlightResponse>>(response.Content);

                flights = FlightMap.MapToDomain(flightsResponse);
            }

            return flights;
        }
    }
}

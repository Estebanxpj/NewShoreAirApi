namespace Domain.Transport
{
    public class Transport
    {
        public string flightCarrier { get; }
        public string flightNumber { get;}

        public Transport(string flightCarrier, string flightNumber)
        {
            this.flightNumber = flightNumber;
            this.flightCarrier = flightCarrier;
        }
    }
}

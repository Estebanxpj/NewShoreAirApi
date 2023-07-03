namespace Domain.Route
{
    public class Route
    {
        public string origin { get;  }

        public string destination { get;  }

        public decimal price { get; set; }

        public Route (string origin, string destination, decimal price = 0)
        {
            this.origin = origin;
            this.destination = destination;
            this.price = price;
        }


    }
}

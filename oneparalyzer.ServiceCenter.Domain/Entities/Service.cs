

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Service
    {
        public int Id { get; private set;  }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public List<Order> Orders { get; set; }

        public Service(string title, decimal price)
        {
            Title = title;
            Price = price;
            Orders = new List<Order>();
        }
    }
}

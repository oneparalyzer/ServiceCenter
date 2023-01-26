using oneparalyzer.ServiceCenter.Domain.Exceptions;


namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Spare
    {
        public int Id { get; private set; }
        public string Title { get; private set; } 
        public string Device { get; private set; } 
        public string Details { get; private set; }
        public decimal Price { get; private set; }
        public uint Quantity { get; private set; }
        public List<SpareOrder> SparesOrders { get; set; } 

        public Spare(string title, string device, decimal price, uint quantity, string details = "Без описания")
        {
            Title = title;
            Device = device;
            Details = details;
            Price = price;
            Quantity = quantity;
            SparesOrders = new List<SpareOrder>();
        }

        public void Add(uint value)
        {
            Quantity += value;
        }

        public void Reduce(uint value)
        {
            if (Quantity < value)
            {
                throw new InvalidArgumentException($"{nameof(value)} > {nameof(Quantity)}");
            }
            Quantity -= value;
        }
    }
}

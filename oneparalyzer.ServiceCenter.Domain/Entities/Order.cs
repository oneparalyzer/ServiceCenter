using oneparalyzer.ServiceCenter.Domain.Enums;

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public OrderStatus Status { get; private set; }
        public Client Client { get; private set; } 
        public List<Service> Services { get; private set; } 
        public List<SpareOrder> Spares { get; set; } 

        public Order(Client client, List<Service> service) : this()
        {
            Client = client;
            Services = service;
            Spares = new List<SpareOrder>();
        }
        private Order()
        {
            
        }

        public void Create()
        {
            Status = OrderStatus.InProgress;
            foreach (var spareOrder in Spares)
            {
                spareOrder.Spare.Reduce(spareOrder.Quantity);
            }
        }

        public decimal CalculatePrice()
        {
            decimal price = 0;
            foreach (var serviceOrder in Spares)
            {
                price += serviceOrder.Spare.Price;
            }
            foreach (var spareOrder in Spares)
            {
                price += spareOrder.Spare.Price * spareOrder.Quantity;
            }
            return price;
        }

        public void StatusSuccess()
        {
            Status = OrderStatus.Success;
        }

        public void StatusRejection()
        {
            Status = OrderStatus.Rejection;
        }

        public void StatusMoneyRefund()
        {
            Status = OrderStatus.MoneyRefund;
        }

    }
}

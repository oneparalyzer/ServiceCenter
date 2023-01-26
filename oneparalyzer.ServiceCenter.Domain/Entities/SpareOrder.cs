

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class SpareOrder
    {
        public int Id { get; private set; }
        public uint Quantity { get; private set; }
        public Spare Spare { get; private set; }
        public Order? Order { get; private set; }

        public SpareOrder(Spare spare, uint quantity) : this(quantity)
        {
            Spare = spare;
        }

        private SpareOrder(uint quantity)
        {
            Quantity = quantity;
        }
    }
}

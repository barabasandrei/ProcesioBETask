namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public required Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}

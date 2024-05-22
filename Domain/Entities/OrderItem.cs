namespace Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        
        public required Order Order { get; set; }
        
        public required Product Product { get; set; }
    }
}
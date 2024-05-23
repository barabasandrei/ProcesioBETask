namespace Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

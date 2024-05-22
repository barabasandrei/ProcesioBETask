namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public bool IsAccountValidated { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

namespace ProcesioWebApi.DTOs.Customers
{
    public class UpdateCustomerDto
    {
        public int CustomerId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }
    }
}

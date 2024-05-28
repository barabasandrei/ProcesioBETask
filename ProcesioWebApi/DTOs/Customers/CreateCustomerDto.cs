namespace ProcesioWebApi.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public required string Name { get; set; }

        public required string Email { get; set; }
    }
}

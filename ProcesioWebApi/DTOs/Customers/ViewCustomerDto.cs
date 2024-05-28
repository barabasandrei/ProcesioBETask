using Domain.Entities;

namespace ProcesioWebApi.DTOs.Customers
{
    public class ViewCustomerDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public bool IsAccountValidated { get; set; }
    }
}

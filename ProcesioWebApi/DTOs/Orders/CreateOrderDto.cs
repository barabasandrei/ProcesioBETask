using ProcesioWebApi.DTOs.OrderItems;

namespace ProcesioWebApi.DTOs.Orders
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; } = [];
    }
}

using Domain.Entities;
using ProcesioWebApi.DTOs.OrderItems;

namespace ProcesioWebApi.DTOs.Orders
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; } = [];
    }
}

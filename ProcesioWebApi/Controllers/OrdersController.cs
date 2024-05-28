using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ProcesioWebApi.DTOs.Customers;
using ProcesioWebApi.DTOs.Orders;

namespace ProcesioWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService, IMapper mapper) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewOrderDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            var orderDtos = _mapper.Map<IEnumerable<ViewOrderDto>>(orders);
            return Ok(orderDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewOrderDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<ViewOrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<ViewOrderDto>> PostOrder(CreateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var createdOrder = await _orderService.AddOrderAsync(order);
            var createdOrderDto = _mapper.Map<ViewOrderDto>(createdOrder);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, UpdateOrderDto orderDto)
        {
            if (id != orderDto.OrderId)
            {
                return BadRequest();
            }

            var order = _mapper.Map<Order>(orderDto);
            var updateSuccessful = await _orderService.UpdateOrderAsync(order);

            if (!updateSuccessful)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleteSuccessful = await _orderService.DeleteOrderAsync(id);

            if (!deleteSuccessful)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

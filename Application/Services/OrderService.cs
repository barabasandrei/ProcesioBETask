using Application.Interfaces;
using Domain.Entities;
using Events;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMessagePublisher _messagePublisher;

        public OrderService(IApplicationDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> AddOrderAsync(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            //TODO: yuck. I'll replace this with an order to ordercreatedevent mapper or something along these lines
            var @event = new OrderCreatedEvent { OrderId = Order.OrderId, CustomerId = Order.CustomerId, CreatedAt = DateTime.Now };
            await _messagePublisher.PublishAsync(@event);

            return Order;
        }

        public async Task<bool> UpdateOrderAsync(Order Order)
        {
            _context.Entry(Order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(e => e.OrderId == Order.OrderId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return false;
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

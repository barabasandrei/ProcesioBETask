using Application.Interfaces;
using MassTransit;

namespace Infrastructure.RabbitMq
{
    public class RabbitMqMessagePublisher : IMessagePublisher
    {
        private readonly IBusControl _bus;

        public RabbitMqMessagePublisher(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync<T>(T message) where T : class
        {
            await _bus.Publish(message);
        }
    }
}

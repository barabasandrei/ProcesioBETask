using Events;
using MassTransit;

namespace RabbitMqListener
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventConsumer> _logger;

        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            _logger.LogInformation($"[*] OrderCreatedEvent: {context.Message}");
            return Task.CompletedTask;
        }
    }
}

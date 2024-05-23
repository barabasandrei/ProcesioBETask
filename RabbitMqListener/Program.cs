using Domain.Entities;
using MassTransit;
using ServiceStack;
using System.Reflection;

namespace RabbitMqListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddLogging();

            builder.Services.AddMassTransit(m =>
            {
                m.AddConsumer<OrderCreatedEventConsumer>();
                m.UsingRabbitMq((ctx, cfg) =>
                    {
                        cfg.Host("host.docker.internal", "/", c =>
                        {
                            c.Username("guest");
                            c.Password("guest");
                        });

                        //cfg.ReceiveEndpoint("queue_name", ep =>
                        //{
                        //    ep.ConfigureConsumer<OrderCreatedEventConsumer>(ctx);
                        //});

                        cfg.ConfigureEndpoints(ctx);
                    });
            });

            var host = builder.Build();
            host.Run();
        }
    }
}
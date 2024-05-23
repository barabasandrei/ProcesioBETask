using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.RabbitMq;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
            var rabbitConnectionString = configuration.GetConnectionString("DefaultRabbitMqConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(dbConnectionString, sqlserverOptions =>
                    {
                        sqlserverOptions.CommandTimeout(20);
                        sqlserverOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
                    });
                });

            services.AddMassTransit(mass =>
            {
                mass.UsingRabbitMq();
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IMessagePublisher, RabbitMqMessagePublisher>();

            return services;
        }
    }
}

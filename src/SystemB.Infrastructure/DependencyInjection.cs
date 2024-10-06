using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SystemB.Infrastructure.Data;
using SystemB.Infrastructure.Queues;

namespace SystemB.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SystemBDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.RegisterRabbitMQ(configuration);

            services.AddHostedService<RabbitMqConsumerService>();
        }

        private static void RegisterRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection("RabbitMQ");
            var factory = new ConnectionFactory
            {
                HostName = rabbitMqSettings["HostName"],
                UserName = rabbitMqSettings["UserName"],
                Password = rabbitMqSettings["Password"]
            };
            services.AddSingleton(factory);
        }
    }
}

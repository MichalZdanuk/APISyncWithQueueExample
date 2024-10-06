using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SystemB.Application.Repositories;
using SystemB.Infrastructure.Data;
using SystemB.Infrastructure.Queues;
using SystemB.Infrastructure.Repositories;

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
            services.RegisterRepositories();
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

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserEventHistoricalRecordRepository, UserEventHistoricalRecordRepository>();
        }
    }
}

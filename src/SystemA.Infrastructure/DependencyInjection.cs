using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SystemA.Application.Queues;
using SystemA.Application.Repositories;
using SystemA.Infrastructure.Data;
using SystemA.Infrastructure.Queues;
using SystemA.Infrastructure.Repositories;

namespace SystemA.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SystemADbContext>(options =>
            options.UseSqlServer(connectionString));

            services.RegisterRabbitMQ(configuration);
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
            services.AddSingleton<IMessagePublisher, RabbitMqMessagePublisher>();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

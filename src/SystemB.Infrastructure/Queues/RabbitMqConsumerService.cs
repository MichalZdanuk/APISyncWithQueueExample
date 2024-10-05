using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SystemA.Contracts.Events.Users;
using System.Text;
using System.Text.Json;
using SystemB.Application.Events;

namespace SystemB.Infrastructure.Queues
{
    public class RabbitMqConsumerService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection;
        private IModel _channel;
        private readonly string _queueName = "UserCreateQueue";

        public RabbitMqConsumerService(ConnectionFactory connectionFactory, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var eventType = ea.RoutingKey;
                if (eventType == "UserCreate")
                {
                    var userCreatedEvent = JsonSerializer.Deserialize<UserCreatedEvent>(message);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<UserCreatedEvent>>();
                        await handler.Handle(userCreatedEvent);
                    }
                }
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.Close();
            _connection?.Close();
            return Task.CompletedTask;
        }
    }
}

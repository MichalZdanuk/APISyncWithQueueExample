using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
        private readonly string _exchangeName = "user_exchange";
        private readonly List<string> _queueNames = new List<string> { "UserCreateQueue", "UserUpdateQueue" };

        public RabbitMqConsumerService(ConnectionFactory connectionFactory, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var queueName in _queueNames)
            {
                _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(_channel);

                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var eventType = ea.RoutingKey;

                    // Get the corresponding event type and deserialize the message
                    if (MessageTypeMap.EventTypeMap.TryGetValue(eventType, out var eventTypeClass))
                    {
                        var @event = JsonSerializer.Deserialize(message, eventTypeClass);

                        if (@event != null)
                        {
                            using var scope = _serviceProvider.CreateScope();
                            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventTypeClass);
                            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

                            var handleMethod = handler.GetType().GetMethod("Handle");
                            if (handleMethod != null)
                            {
                                await (Task)handleMethod.Invoke(handler, new[] { @event });
                            }
                        }
                    }
                };

                _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            }

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

using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using SystemA.Application.Queues;

namespace SystemA.Infrastructure.Queues
{
    public class RabbitMqMessagePublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqMessagePublisher(ConnectionFactory connectionFactory)
        {
            try
            {
                _connection = connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to establish connection to RabbitMQ.", ex);
            }
        }

        public async Task PublishAsync<T>(T message, string routingKey) where T : IMessage
        {
            try
            {
                var exchangeName = "user_exchange";
                _channel.ExchangeDeclare(exchange: exchangeName, type: "direct", durable: true);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: properties, body: body);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to publish message to RabbitMQ. RoutingKey: {routingKey}", ex);
            }

            await Task.CompletedTask;
        }
    }
}

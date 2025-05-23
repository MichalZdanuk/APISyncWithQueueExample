﻿using RabbitMQ.Client;
using RabbitMQInitializer;

var factory = new ConnectionFactory()
{ 
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
};

try
{
    // 1. Establish connection to RabbitMQ
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();

    // 2. Declare an exchange
    string exchangeName = "user_exchange";
    channel.ExchangeDeclare(exchange: exchangeName, type: "direct", durable: true, autoDelete: false);
    ConsoleLogger.LogSuccess($"Exchange '{exchangeName}' created.");

    // 3. Declare queues
    string userCreateQueue = "UserCreateQueue";
    string userUpdateQueue = "UserUpdateQueue";

    channel.QueueDeclare(queue: userCreateQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
    channel.QueueDeclare(queue: userUpdateQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
    ConsoleLogger.LogSuccess($"Queues '{userCreateQueue}' and '{userUpdateQueue}' created.");

    // 4. Bind the queues to the exchange with appropriate routing keys
    channel.QueueBind(queue: userCreateQueue, exchange: exchangeName, routingKey: "UserCreate");
    channel.QueueBind(queue: userUpdateQueue, exchange: exchangeName, routingKey: "UserUpdate");
    ConsoleLogger.LogSuccess($"Queues bound to exchange with routing keys 'UserCreate' and 'UserUpdate'.");

    // Program completed successfully
    ConsoleLogger.LogSuccess("RabbitMQ setup complete.");
}
catch (Exception ex)
{
    ConsoleLogger.LogError($"An error occurred: {ex.Message}");
}
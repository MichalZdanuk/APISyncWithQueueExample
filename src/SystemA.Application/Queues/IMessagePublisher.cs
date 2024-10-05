namespace SystemA.Application.Queues
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message, string routingKey) where T : IMessage;
    }
}

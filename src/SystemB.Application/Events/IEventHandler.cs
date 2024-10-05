using Shared.Queues;

namespace SystemB.Application.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IMessage
    {
        Task Handle(TEvent @event);
    }
}

namespace SystemB.Application.Events
{
    public interface IEventHandler<in TEvent>
    {
        Task Handle(TEvent @event);
    }
}

using MediatR;

namespace DomainEvent.EventsHandlers;

public interface IDomainEvent
{
    Task PushEvent<TEventData>(TEventData eventData);
}

// Реализация доменного события, которое может пушить события
public class DomainEvent : BaseDomainEvent, IDomainEvent
{
    private readonly IMediator _mediator;

    public DomainEvent(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task PushEvent<TEventData>(TEventData eventData)
    {
        var notification = new DomainNotification<TEventData>(eventData);
        AddDomainEvent(notification);

        Console.WriteLine("Event pushed.");

        var publishTasks = DomainEvents.Select(domainEvent => _mediator.Publish(domainEvent));
        await Task.WhenAll(publishTasks);

        ClearDomainEvents();
    }

}

// Обобщённый класс для уведомлений, принимающий данные события
public class DomainNotification<TEventData> : INotification
{
    public TEventData EventData { get; }
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime EventDate { get; } = DateTime.UtcNow;

    public DomainNotification(TEventData eventData)
    {
        EventData = eventData;
    }
}


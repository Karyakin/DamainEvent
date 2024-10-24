// Абстрактный базовый класс для доменных событий

using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace DomainEvent.EventsHandlers;

public abstract class BaseDomainEvent
{
    [NotMapped]
    public List<INotification> DomainEvents { get; } = new List<INotification>();

    protected void AddDomainEvent(INotification eventItem)
    {
        DomainEvents.Add(eventItem);
    }

    protected void RemoveDomainEvent(INotification eventItem)
    {
        DomainEvents.Remove(eventItem);
    }

    protected void ClearDomainEvents()
    {
        DomainEvents.Clear();
    }
}
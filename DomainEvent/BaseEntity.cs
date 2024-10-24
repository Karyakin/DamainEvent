using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace DomainEvent
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [NotMapped]
        public List<INotification> DomainEvents { get; } = new List<INotification>();

        public void QueueDomainEvent(INotification @event)
        {
            DomainEvents.Add(@event);
        }
    }
}
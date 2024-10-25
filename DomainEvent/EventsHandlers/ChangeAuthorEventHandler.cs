using MediatR;

namespace DomainEvent.EventsHandlers;

public class ChangeAuthorEventHandler : INotificationHandler<DomainNotification<ChangeAuthorResultEventData>>
{
    public Task Handle(DomainNotification<ChangeAuthorResultEventData> notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Change notification completed");
        Console.WriteLine($"Affected - {notification.EventData.Affected}");
        return Task.CompletedTask;
    }
}
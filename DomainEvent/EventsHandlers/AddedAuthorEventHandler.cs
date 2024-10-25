// Обработчик события добавления автора

using MediatR;

namespace DomainEvent.EventsHandlers;

public class AddedAuthorEventHandler : INotificationHandler<DomainNotification<AddedAuthorEventData>>
{
    public Task Handle(DomainNotification<AddedAuthorEventData> notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"AddedAuthor event handled. Event ID: {notification.EventId}, Event Date: {notification.EventDate}");
        Console.WriteLine($"Author Name: {notification.EventData.AuthorName}");
        return Task.CompletedTask;
    }
}
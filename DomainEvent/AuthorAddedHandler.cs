using MediatR;

namespace DomainEvent;

public class AuthorAddedHandler : INotificationHandler<AuthorAdded>
{
    private readonly ILogger<AuthorAddedHandler> _logger;

    public AuthorAddedHandler(ILogger<AuthorAddedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AuthorAdded notification, CancellationToken cancellationToken)
    {
        if (notification?.Author == null)
        {
            throw new ArgumentNullException(nameof(notification.Author), "Author cannot be null.");
        }

        _logger.LogInformation($"Handling AuthorAdded event for {notification.Author.Name}");
        return Task.CompletedTask;
    }
    
    public class AuthorUpdatedHandler : INotificationHandler<AuthorUpdated>
    {
        private readonly ILogger<AuthorUpdatedHandler> _logger;

        public AuthorUpdatedHandler(ILogger<AuthorUpdatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AuthorUpdated notification, CancellationToken cancellationToken)
        {
            if (notification?.Author == null)
            {
                throw new ArgumentNullException(nameof(notification.Author), "Author cannot be null.");
            }

            _logger.LogInformation($"Handling AuthorUpdated event for {notification.Author.Name}");
            return Task.CompletedTask;
        }
    }
}
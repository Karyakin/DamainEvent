using MediatR;

namespace DomainEvent;

public interface IDispatchDomainEvents
{
    public Task DispatchAsync(Author author);
}

public class DispatchDomainEvents : IDispatchDomainEvents
{
    private readonly IMediator _mediator;

    public DispatchDomainEvents(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAsync(Author author)
    {
        var tasks = author.DomainEvents.Select(domainEvent => _mediator.Publish(domainEvent));
        await Task.WhenAll(tasks);
        author.DomainEvents.Clear(); // Очищаем события после публикации
    }
}
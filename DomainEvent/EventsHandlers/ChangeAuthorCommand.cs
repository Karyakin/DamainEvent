using MediatR;

namespace DomainEvent.EventsHandlers;

public class ChangeAuthorCommand : IRequest<int>
{
}

public class ChangeAuthorCommandHandler : IRequestHandler<ChangeAuthorCommand, int>
{
    private readonly IDomainEvent _event;

    public ChangeAuthorCommandHandler(IDomainEvent @event)
    {
        _event = @event ?? throw new ArgumentNullException(nameof(@event));
    }

    public async Task<int> Handle(ChangeAuthorCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Change author completed.");

        await _event.PushEvent(new ChangeAuthorResultEventData(777));
        return 777;
    }
}

public class ChangeAuthorResultEventData
{
    public ChangeAuthorResultEventData(int affected)
    {
        Affected = affected;
    }

    public int Affected { get; set; }
}
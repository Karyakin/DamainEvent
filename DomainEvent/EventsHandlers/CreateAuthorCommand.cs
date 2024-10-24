using MediatR;

namespace DomainEvent.EventsHandlers
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public CreateAuthorCommand(string name, string biography)
        {
            Name = name;
            Biography = biography;
        }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IDomainEvent _event;

        public CreateAuthorCommandHandler(IDomainEvent @event)
        {
            _event = @event ?? throw new ArgumentNullException(nameof(@event));
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorId = Guid.NewGuid();
            
            Console.WriteLine($"Author created with ID: {authorId}, Name: {request.Name}");

            try
            {
                // Создаем данные для события добавления автора
                var eventData = new AddedAuthorEventData(request.Name);
                
                // Передаем данные события в метод PushEvent
                await _event.PushEvent(eventData);
            }
            catch (Exception ex)
            {
                // Обработка исключений и логирование ошибки
                Console.WriteLine($"Error pushing event: {ex.Message}");
                throw;
            }

            return authorId;
        }
    }

    // Класс данных события для добавления автора
    public class AddedAuthorEventData
    {
        public string AuthorName { get; }

        public AddedAuthorEventData(string authorName)
        {
            AuthorName = authorName;
        }
    }
}
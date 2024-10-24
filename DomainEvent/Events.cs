using MediatR;

namespace DomainEvent
{
    public class AuthorAdded : INotification
    {
        public Author Author { get; }

        public AuthorAdded(Author author)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }
    }
    
    public class AuthorUpdated : INotification
    {
        public Author Author { get; }

        public AuthorUpdated(Author author)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }
    }
}
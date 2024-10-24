namespace DomainEvent
{
    public class Author : BaseEntity
    {
        public string Name { get; private set; }

        private Author(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static Author Create(string name)
        {
            var newAuthor = new Author(name);
            newAuthor.QueueDomainEvent(new AuthorAdded(newAuthor));

            Console.WriteLine("Author Created.");
            return newAuthor;
        }

        public void UpdateName(string newName)
        {
            Name = newName ?? throw new ArgumentNullException(nameof(newName));
            QueueDomainEvent(new AuthorUpdated(this));

            Console.WriteLine("Author Updated.");
        }
    }
}
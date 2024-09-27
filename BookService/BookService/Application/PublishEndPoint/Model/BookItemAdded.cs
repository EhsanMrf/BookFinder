namespace Application.PublishEndPoint.Model;

internal class BookItemAdded(Guid id, string title, int publishYear, string authorName, DateTime dateTime)
{
    public Guid Id { get; set; } = id;
    public string Title { get; set; } = title;
    public int PublishYear { get; set; } = publishYear;
    public string AuthorName { get; set; } = authorName;
    public DateTime DateTime { get; set; } = dateTime;
}

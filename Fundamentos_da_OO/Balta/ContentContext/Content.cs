namespace Balta.ContentContext;

public abstract class Content
{
    public Content(string title, string url)
    {
        Id = Guid.NewGuid(); // SPOF: single point of failure
        Title = title;
        Url = url;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}
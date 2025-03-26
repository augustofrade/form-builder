using FormBuilder.Domain.Shared;

namespace FormBuilder.Domain.Forms;

public class Form : IAuditable
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string PublicId { get; private init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; private init; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; }
    public List<Submission> Submissions { get; private init; } = [];
    public List<Question> Questions { get; private init; } = [];

    private Form() { }

    private Form(string title, string description)
    {
        Title = title;
        Description = description;
        PublicId = CreatePublicId();
    }
    
    public static Form Create(string title, string description)
    {
        return new Form(title, description);
    }

    private string CreatePublicId()
    {
        // TODO: Create public id creation
        return "public_id";
    }
}
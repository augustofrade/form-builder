using FormBuilder.Domain.Shared;
using shortid;
using shortid.Configuration;

namespace FormBuilder.Domain.Forms;

public class Form : IAuditable
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string PublicId { get; private init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; private init; } = DateTime.Now;
    public DateTime? ModifiedAt { get; set; }
    public List<Submission> Submissions { get; private set; } = [];
    public List<Question> Questions { get; private set; } = [];

    private Form() { }

    private Form(string title, string description, IEnumerable<Question> questions)
    {
        Title = title;
        Description = description;
        Questions = questions.ToList();
        PublicId = CreatePublicId();
    }
    
    public static Form Create(string title, string description, IEnumerable<Question> questions)
    {
        return new Form(title, description, questions);
    }

    private string CreatePublicId()
    {
        var options = new GenerationOptions(useSpecialCharacters: false, length: 8);
        return ShortId.Generate(options);
    }
}
using FormBuilder.Domain.Shared;

namespace FormBuilder.Domain.Forms;

public class Answer : IAuditable
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Value { get; set; }
    public DateTime CreatedAt { get; private init; } = DateTime.Now;
    public DateTime ModifiedAt { get; }
    public Guid SubmissionId { get; private init; }
    public Submission Submission { get; private init; }
    public Guid QuestionId { get; private init; }
    public Question Question { get; private init; }
    
    private Answer() { }

    private Answer(string value, Guid questionId)
    {
        Value = value;
        QuestionId = questionId;
    }

    public static Answer Create(string value, Guid questionId)
    {
        return new Answer(value, questionId);
    }
}
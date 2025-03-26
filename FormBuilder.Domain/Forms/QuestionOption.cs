namespace FormBuilder.Domain.Forms;

public class QuestionOption
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Value { get; set; }
    public string Label { get; set; }
    public Guid QuestionId { get; private init; }
    public Question Question { get; private init; }
    
    private QuestionOption() { }

    private QuestionOption(string value, string label)
    {
        Value = value;
        Label = label;
    }

    public static QuestionOption Create(string value, string label)
    {
        return new QuestionOption(value, label);
    }
}
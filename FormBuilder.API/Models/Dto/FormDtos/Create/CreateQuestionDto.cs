using FormBuilder.Domain.Forms;

namespace FormBuilder.API.Models.Dto.FormDtos.Create;

public class CreateQuestionDto
{
    public string Label { get; init; }
    public QuestionTypes Type { get; init; }
    public bool IsRequired { get; init; }
    public QuestionConstraintDto? Constraint { get; init; }
    public IEnumerable<QuestionOptionDto>? Options { get; init; }
    
    public bool HasOptions => Options != null && Options.Any();
}
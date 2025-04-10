using Microsoft.Extensions.Options;

namespace FormBuilder.API.Models.Dto.FormDtos.Update;

public class UpdateQuestionDto
{
    public Guid Id { get; init; }
    public string Label { get; init; }
    public bool IsRequired { get; init; }
    public QuestionConstraintDto? Constraints { get; init; }
    public List<QuestionOptionDto> Options { get; init; } = [];
    public IEnumerable<Guid> OptionsToDelete { get; init; } = [];
    
    public bool HasOptions =>  Options.Count > 0;
    public bool HasOptionsToDelete =>  OptionsToDelete.Any();
}
namespace FormBuilder.API.Models.Dto.FormDtos.Update;

public class UpdateFormDto
{
    public string Title { get; init; }
    public string Description { get; init; }
    public IEnumerable<UpdateQuestionDto>? QuestionsToUpdate { get; init; }
    public IEnumerable<Guid>? QuestionsToDelete { get; set; }
    
    public bool HasQuestionsToUpdate => QuestionsToUpdate != null && QuestionsToUpdate.Any();
    public bool HasQuestionsToDelete => QuestionsToDelete != null && QuestionsToDelete.Any();
}
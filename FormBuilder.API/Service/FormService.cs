using FormBuilder.API.Models.Dto.FormDtos;
using FormBuilder.API.Models.Dto.FormDtos.Create;
using FormBuilder.Domain.Context;
using FormBuilder.Domain.Forms;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.API.Service;

public interface IFormService
{
    Task<List<FormDto>> GetForms();
    Task<FormDetailsDto?> GetForm(Guid id);
    Task<Form> SaveForm(CreateFormDto createDto);
    Task<Form> UpdateForm(Form form);
} 

public class FormService(ApplicationDbContext db) : IFormService
{
    public Task<List<FormDto>> GetForms()
    {
        return db.Form
            .Select(f => new FormDto
            {
                PublicId = f.PublicId,
                Id = f.Id,
                Title = f.Title,
                Description = f.Description,
                CreatedAt = f.CreatedAt
            }).ToListAsync();
    }

    public Task<FormDetailsDto?> GetForm(Guid id)
    {
        return db.Form
            .Include(f => f.Questions)
            .ThenInclude(q => q.Options)
            .Select(f => new FormDetailsDto
            {
                Id = f.Id,
                PublicId = f.PublicId,
                Title = f.Title,
                Description = f.Description,
                CreatedAt = f.CreatedAt,
                Questions = f.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Label = q.Label,
                    Type =  q.Type,
                    IsDeleted =  q.IsDeleted,
                    Options = q.Options != null ? q.Options.Select(o => new QuestionOptionDto
                    {
                        Id = o.Id,
                        Value = o.Value,
                        Label =  o.Label,
                    }).ToList() : null
                }).ToList()
            }).SingleOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Form> SaveForm(CreateFormDto createDto)
    {
        var questions = createDto.Questions.Select(q =>
        {
            var constraintDto = q.Constraint;
            var constraint = QuestionConstraint.Create(
                constraintDto.Required,
                constraintDto.MinLength,
                constraintDto.MaxLength);
            
            var question = Question.Create(q.Label, constraint, q.Type);
            // return question;
            if(!q.HasOptions)
                return question;
            
            foreach (var optionDto in q.Options)
            {
                question.AddOption(QuestionOption.Create(optionDto.Value, optionDto.Label));
            }
            return question;
        }).ToList();
        var form = Form.Create(createDto.Title, createDto.Description, questions);
        await  db.Form.AddAsync(form);
        await db.SaveChangesAsync();
        return form;
    }

    public Task<Form> UpdateForm(Form form)
    {
        throw new NotImplementedException();
    }
}
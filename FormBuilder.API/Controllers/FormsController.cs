using System.ComponentModel;
using System.Globalization;
using FormBuilder.API.Models.Dto.FormDtos.Create;
using FormBuilder.API.Service;
using FormBuilder.API.Extensions;
using FormBuilder.API.Models.Dto.FormDtos.Update;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace FormBuilder.API.Controllers;

[Route("api/forms")]
[ApiController]
public class FormsController(IFormService formService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetForms()
    {
        var forms = await formService.GetForms();
        return Ok(forms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetForm(Guid id)
    {
        var form = await formService.GetForm(id);
        return Ok(form);
    }

    [HttpPost]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormDto dto)
    {
        var form = await formService.SaveForm(dto);
        return Ok(form.ToDetailsDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateForm(Guid id, [FromBody] UpdateFormDto dto)
    {
        var form = await formService.UpdateForm(id, dto);
        return Ok(form.ToDetailsDto());
    }
}
using FormBuilder.API.Service;
using FormBuilder.Domain.Forms;
using Microsoft.AspNetCore.Mvc;

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
}
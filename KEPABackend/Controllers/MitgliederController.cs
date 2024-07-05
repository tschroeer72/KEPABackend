using KEPABackend.DTOs;
using KEPABackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

[ApiController]
[Route("[controller]")]
public class MitgliederController : ControllerBase
{
    public MitgliederService MitgliederCreateService { get; }

    public MitgliederController(MitgliederService mitgliederCreateService)
    {
        MitgliederCreateService = mitgliederCreateService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMitglieder(MitgliedCreate mitgliedCreate)
    {
        var result = await MitgliederCreateService.CreateMitgliederAsync(mitgliedCreate);
        return Ok(result);
    }
}

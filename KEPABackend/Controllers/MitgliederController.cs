using KEPABackend.DTOs;
using KEPABackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MitgliederController : ControllerBase
{
    public MitgliederService MitgliederService { get; }

    public MitgliederController(MitgliederService mitgliederCreateService)
    {
        MitgliederService = mitgliederCreateService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMitglieder(MitgliedCreate mitgliedCreate)
    {
        var result = await MitgliederService.CreateMitgliederAsync(mitgliedCreate);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllMitglieder")]
    public async Task<ActionResult> GetAllMitglieder()
    {
        var result = await MitgliederService.GetAllMitgliederAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("GetMitgliedByID")]
    public async Task<ActionResult> GetMitgliedByID(int ID)
    {
        var result = await MitgliederService.GetMitgliedByIDAsync(ID);
        return Ok(result);
    }
}

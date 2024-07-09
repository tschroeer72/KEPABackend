using KEPABackend.DTOs.Post;
using KEPABackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Meisterschaften
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MeisterschaftController : ControllerBase
{
    private MeisterschaftService MeisterschaftService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftService"></param>
    public MeisterschaftController(MeisterschaftService meisterschaftService)
    {
        MeisterschaftService = meisterschaftService;
    }

    /// <summary>
    /// Anlegen einer neuen Meisterschaft
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>MeisterschaftsID</returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMeisterschaft(MeisterschaftCreate meisterschaftCreate)
    {
        var result = await MeisterschaftService.CreateMeisterschaft(meisterschaftCreate);
        return Ok(result);
    }
}

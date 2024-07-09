using KEPABackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Meisterschaftstypen
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MeisterschaftstypController : ControllerBase
{
    private MeisterschaftstypService MeisterschaftstypService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftstypService"></param>
    public MeisterschaftstypController(MeisterschaftstypService meisterschaftstypService)
    {
        MeisterschaftstypService = meisterschaftstypService;
    }

    /// <summary>
    /// Liste aller Meisterschaftstypen
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    [HttpGet]
    [Route("GetAllMeisterschaftstypen")]
    public async Task<ActionResult> GetAllMeisterschaftstypen()
    {
        var result = await MeisterschaftstypService.GetAllMeisterschaftstypen();
        return Ok(result);
    }

    /// <summary>
    /// Meisterschaftstyp
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp</returns>
    /// <response code="200">Meisterschaftstyp gefunden</response>
    /// <response code="404">Meisterschaftstyp nicht gefunden</response>
    [HttpGet]
    [Route("GetMeisterschaftstypByID")]
    public async Task<ActionResult> GetMeisterschaftstypByID(int ID)
    {
        var result = await MeisterschaftstypService.GetMeisterschaftstypByID(ID);
        return Ok(result);
    }
}

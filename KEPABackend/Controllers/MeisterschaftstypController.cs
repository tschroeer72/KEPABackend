using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;
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
    private IMeisterschaftstypenService MeisterschaftstypService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftService"></param>
    public MeisterschaftstypController(IMeisterschaftstypenService meisterschaftService)
    {
        MeisterschaftstypService = meisterschaftService;
    }

    /// <summary>
    /// Liste aller Meisterschaftstypen
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    /// <response code="200">Meisterschaftstypen gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(Meisterschaftstypen), 200)]
    [Route("GetAllMeisterschaftstypen")]
    public async Task<ActionResult> GetAllMeisterschaftstypen()
    {
        var result = await MeisterschaftstypService.GetAllMeisterschaftstypenAsync();
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
    [ProducesResponseType(typeof(Meisterschaftstypen), 200)]
    [Route("GetMeisterschaftstypByID")]
    public async Task<ActionResult> GetMeisterschaftstypByID(int ID)
    {
        var result = await MeisterschaftstypService.GetMeisterschaftstypByIDAsync(ID);
        return Ok(result);
    }
}

using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// Spielergebnisse
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpielergebnisseController : ControllerBase
{
    private readonly ISpielergebnisseService spielergebnisseService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="spielergebnisseService"></param>
    public SpielergebnisseController(ISpielergebnisseService spielergebnisseService)
    {
        this.spielergebnisseService = spielergebnisseService;
    }

    /// <summary>
    /// Liste aller Neuner/Ratten
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Neuner/Ratten</param>
    /// <returns>Liste aller Neuner/Ratten</returns>
    /// <response code="200">Neuner/Ratten gefunden</response>
    [HttpGet]
    [Route("GetAllMeisterschaften")]
    public async Task<ActionResult> GetAllMeisterschaften(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetAllErgebnisseNeunerRattenAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle 6-Tage-Rennen</param>
    /// <returns>Liste aller 6-Tage-Rennen</returns>
    /// <response code="200">6-Tage-Rennen gefunden</response>
    [HttpGet]
    [Route("GetAll6TageRennen")]
    public async Task<ActionResult> GetAllErgebnisse6TageRennen(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetAllErgebnisse6TageRennenAsync(SpieltagID);
        return Ok(result);
    }
}

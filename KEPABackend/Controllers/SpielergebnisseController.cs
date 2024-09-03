using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// Spielergebnisse
/// </summary>
[Authorize]
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
    [ProducesResponseType(typeof(vwNeunerRatten), 200)]
    [Route("GetNeunerRatten")]
    public async Task<ActionResult> GetMeisterschaften(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisseNeunerRattenAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle 6-Tage-Rennen</param>
    /// <returns>Liste aller 6-Tage-Rennen</returns>
    /// <response code="200">6-Tage-Rennen gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpiel6TageRennen), 200)]
    [Route("Get6TageRennen")]
    public async Task<ActionResult> GetErgebnisse6TageRennen(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisse6TageRennenAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Pokalspiele
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Pokalspiele</param>
    /// <returns>Liste aller Pokalspiele</returns>
    /// <response code="200">Pokalspiele gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpielPokal), 200)]
    [Route("GetPokal")]
    public async Task<ActionResult> GetErgebnissePokal(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnissePokalAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Sargkegeln
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Sargkegeln</param>
    /// <returns>Liste aller Sargkegeln</returns>
    /// <response code="200">Sargkegeln gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpielSargkegeln), 200)]
    [Route("GetSargkegeln")]
    public async Task<ActionResult> GetErgebnisseSargkegeln(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisseSargkegelnAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Blitztuniere
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Blitztuniere</param>
    /// <returns>Liste aller Blitztuniere</returns>
    /// <response code="200">Blitztuniere gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpielBlitztunier), 200)]
    [Route("GetBlitztunier")]
    public async Task<ActionResult> GetErgebnisseBlitztunier(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisseBlitztunierAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Meisterschaft
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Meisterschaft</param>
    /// <returns>Liste aller Meisterschaft</returns>
    /// <response code="200">Meisterschaft gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpielMeisterschaft), 200)]
    [Route("GetMeisterschaft")]
    public async Task<ActionResult> GetErgebnisseMeisterschaft(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisseMeisterschaftAsync(SpieltagID);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Kombimeisterschaft
    /// </summary>
    /// <param name="SpieltagID"> -1 = alle Kombimeisterschaft</param>
    /// <returns>Liste aller Kombimeisterschaft</returns>
    /// <response code="200">Kombimeisterschaft gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(vwSpielKombimeisterschaft), 200)]
    [Route("GetKombimeisterschaft")]
    public async Task<ActionResult> GetErgebnisseKombimeisterschaft(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetErgebnisseKombimeisterschaftAsync(SpieltagID);
        return Ok(result);
    }
}

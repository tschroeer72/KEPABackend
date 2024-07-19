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
    /// <returns>Liste aller Neuner/Ratten</returns>
    /// <response code="200">Neuner/Ratten gefunden</response>
    [HttpGet]
    [Route("GetAllMeisterschaften")]
    public async Task<ActionResult> GetAllMeisterschaften(int SpieltagID = -1)
    {
        var result = await spielergebnisseService.GetAllErgebnisseNeunerRattenAsync(SpieltagID);
        return Ok(result);
    }
}

using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Mitglieder
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MitgliederController : ControllerBase
{
    private IMitgliederService MitgliederService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mitgliederCreateService"></param>
    public MitgliederController(IMitgliederService mitgliederCreateService)
    {
        MitgliederService = mitgliederCreateService;
    }

    /// <summary>
    /// Anlegen eines neuen Mitglieds
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns>die geänderte Entität</returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMitglieder(MitgliedCreate mitgliedCreate)
    {
        var result = await MitgliederService.CreateMitgliederAsync(mitgliedCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Ändern eines vorhandenen Mitglieds
    /// </summary>
    /// <param name="mitgliedUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Mitglied nicht gefunden</response>
    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult> UpdateMitglieder(MitgliedUpdate mitgliedUpdate)
    {
        var result = await MitgliederService.UpdateMitgliederAsync(mitgliedUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Liste aller Mitglieder
    /// </summary>
    /// <param name="Aktiv"></param>
    /// <returns></returns>
    /// <response code="200">Mitglieder gefunden</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet]
    [ProducesResponseType(typeof(Mitgliederliste), 200)]
    [Route("GetAllMitglieder")]
    public async Task<ActionResult> GetAllMitglieder(bool Aktiv = true)
    {
        var result = await MitgliederService.GetAllMitgliederAsync(Aktiv);
        return Ok(result);
    }

    /// <summary>
    /// Rückgabe eines bestimmten Mitglieds
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <response code="200">Mitglied gefunden</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Mitglied nicht gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(Mitgliederliste), 200)]
    [Route("GetMitgliedByID")]
    public async Task<ActionResult> GetMitgliedByID(int ID)
    {
        var result = await MitgliederService.GetMitgliedByIDAsync(ID);
        return Ok(result);
    }
}

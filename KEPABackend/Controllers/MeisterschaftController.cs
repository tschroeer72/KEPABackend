using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Meisterschaften
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MeisterschaftController : ControllerBase
{
    private IMeisterschaftService MeisterschaftService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftService"></param>
    public MeisterschaftController(IMeisterschaftService meisterschaftService)
    {
        MeisterschaftService = meisterschaftService;
    }

    /// <summary>
    /// Anlegen einer neuen Meisterschaft
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>MeisterschaftsID</returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">MeisterschaftstypNotFoundException</response>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMeisterschaft(MeisterschaftCreate meisterschaftCreate)
    {
        var result = await MeisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Update einer Meisterschaft
    /// </summary>
    /// <param name="meisterschaftUpdate"></param>
    /// <returns>die geänderte Entität</returns>
    /// <response code="205">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">[MeisterschaftNotFoundException | MeisterschaftstypNotFoundException]</response>
    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult> UpdateMeisterschaft(MeisterschaftUpdate meisterschaftUpdate)
    {
        var result = await MeisterschaftService.UpdateMeisterschaftAsync(meisterschaftUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    /// <response code="200">Meisterschaften gefunden</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet]
    [ProducesResponseType(typeof(Meisterschaft), 200)]
    [Route("GetAllMeisterschaften")]
    public async Task<ActionResult> GetAllMeisterschaften()
    {
        var result = await MeisterschaftService.GetAllMeisterschaftenAsync();
        return Ok(result);
    }

    /// <summary>
    /// Rückgabe einer bestimmten Meisterschaft
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <response code="200">Meisterschaft gefunden</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Meisterschaft nicht gefunden</response>
    [HttpGet]
    [ProducesResponseType(typeof(Meisterschaft), 200)]
    [Route("GetMeisterschaftByID")]
    public async Task<ActionResult> GetMeisterschaftdByID(int ID)
    {
        var result = await MeisterschaftService.GetMeisterschaftByIDAsync(ID);
        return Ok(result);
    }

    /// <summary>
    /// Teilnehmer zu einer Meisterschaft hinzufügen
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="TeilnehmerID"></param>
    /// <returns></returns>
    /// <response code="201">Hinzufügen erfolgreich</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Meisterschaft nicht gefunden | Teilnehmer nicht gefunden</response>
    [HttpPost]
    [Route("AddTeilnehmer")]
    public async Task<ActionResult> AddTeilnehmer(int MeisterschaftsID, int TeilnehmerID)
    {
        await MeisterschaftService.AddTeilnehmerAsync(MeisterschaftsID, TeilnehmerID);
        return Created("/", "");
    }

    /// <summary>
    /// Teilnehmer aus einer Meisterschaft löschen
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="TeilnehmerID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Meisterschaft nicht gefunden | Teilnehmer nicht gefunden</response>
    [HttpDelete]
    [Route("DeleteTeilnehmer")]
    public async Task<ActionResult> DeleteTeilnehmer(int MeisterschaftsID, int TeilnehmerID)
    {
        await MeisterschaftService.DeleteTeilnehmerAsync(MeisterschaftsID, TeilnehmerID);
        //return Ok();
        return NoContent();
    }
}

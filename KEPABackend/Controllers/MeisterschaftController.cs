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
    /// <response code="404">MeisterschaftstypNotFoundException</response>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMeisterschaft(MeisterschaftCreate meisterschaftCreate)
    {
        var result = await MeisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);
        return Ok(result);
    }

    /// <summary>
    /// Update einer Meisterschaft
    /// </summary>
    /// <param name="meisterschaftUpdate"></param>
    /// <returns>die geänderte Entität</returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">[MeisterschaftNotFoundException | MeisterschaftstypNotFoundException]</response>
    [HttpPost]
    [Route("Update")]
    public async Task<ActionResult> UpdateMeisterschaft(MeisterschaftUpdate meisterschaftUpdate)
    {
        var result = await MeisterschaftService.UpdateMeisterschaftAsync(meisterschaftUpdate);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    [HttpGet]
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
    /// <response code="404">Meisterschaft nicht gefunden</response>
    [HttpGet]
    [Route("GetMeisterschaftByID")]
    public async Task<ActionResult> GetMeisterschaftdByID(int ID)
    {
        var result = await MeisterschaftService.GetMeisterschaftByIDAsync(ID);
        return Ok(result);
    }
}

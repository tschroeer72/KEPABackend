using KEPABackend.DTOs.Post;
using KEPABackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Mitglieder
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MitgliederController : ControllerBase
{
    private MitgliederService MitgliederService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mitgliederCreateService"></param>
    public MitgliederController(MitgliederService mitgliederCreateService)
    {
        MitgliederService = mitgliederCreateService;
    }

    /// <summary>
    /// Anlegen eines neuen Mitglieds
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns></returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="400">Validation Error</response>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateMitglieder(MitgliedCreate mitgliedCreate)
    {
        var result = await MitgliederService.CreateMitgliederAsync(mitgliedCreate);
        return Ok(result);
    }

    /// <summary>
    /// Ändern eines vorhandenen Mitglieds
    /// </summary>
    /// <param name="mitgliedUpdate"></param>
    /// <returns></returns>
    /// <response code="200">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">Mitglied nicht gefunden</response>
    [HttpPost]
    [Route("Update")]
    public async Task<ActionResult> UpdateMitglieder(MitgliedUpdate mitgliedUpdate)
    {
        var result = await MitgliederService.UpdateMitgliederAsync(mitgliedUpdate);
        return Ok(result);
    }

    /// <summary>
    /// Liste aller Mitglieder
    /// </summary>
    /// <param name="Aktiv"></param>
    /// <returns></returns>
    [HttpGet]
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
    /// <response code="404">Mitglied nicht gefunden</response>
    [HttpGet]
    [Route("GetMitgliedByID")]
    public async Task<ActionResult> GetMitgliedByID(int ID)
    {
        var result = await MitgliederService.GetMitgliedByIDAsync(ID);
        return Ok(result);
    }
}

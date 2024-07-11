using KEPABackend.DTOs.Post;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Mitglieder
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SpieleingabeController : ControllerBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpieleingabeController()
    {
        
    }

    /// <summary>
    /// Erzeuge einen Spieltag
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>ID des Spieltages</returns>
    [HttpPost]
    [Route("CreateSpieltag")]
    public async Task<ActionResult> CreateSpieltag(int MeisterschaftsID, DateTime Spieltag)
    {
        return Ok(1);
    }

    /// <summary>
    /// Spieltag beenden
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CloseSpieltag")]
    public async Task<ActionResult> CloseSpieltag(int SpieltagID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Ermittlung des Spieltages in Bearbeitung
    /// </summary>
    /// <returns>ID und Datum des Spieltages</returns>
    [HttpGet]
    [Route("GetAktuellerSpieltag")]
    public async Task<ActionResult> GetAktuellerSpieltag()
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er/Ratten
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Create9erRatten")]
    public async Task<ActionResult> Create9erRatten(int SpieltagID, int SpielerID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Spieler1ID"></param>
    /// <param name="Spieler2ID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Create6TageRennen")]
    public async Task<ActionResult> Create6TageRennen(int SpieltagID, int Spieler1ID, int Spieler2ID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Blitztunier
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Spieler1ID"></param>
    /// <param name="Spieler2ID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CreateBlitztunier")]
    public async Task<ActionResult> CreateBlitztunier(int SpieltagID, int Spieler1ID, int Spieler2ID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Meisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Spieler1ID"></param>
    /// <param name="Spieler2ID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CreateMeisterschaft")]
    public async Task<ActionResult> CreateMeisterschaft(int SpieltagID, int Spieler1ID, int Spieler2ID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Kombimeisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Spieler1ID"></param>
    /// <param name="Spieler2ID"></param>
    /// <param name="HinRückrunde"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CreateKombimeisterschaft")]
    public async Task<ActionResult> CreateKombimeisterschaft(int SpieltagID, int Spieler1ID, int Spieler2ID, int HinRückrunde)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Pokal
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CreatePokal")]
    public async Task<ActionResult> CreatePokal(int SpieltagID, int SpielerID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Sargkegeln
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("CreateSargkegeln")]
    public async Task<ActionResult> CreateSargkegeln(int SpieltagID, int SpielerID)
    {
        return Ok(1);
    }
}

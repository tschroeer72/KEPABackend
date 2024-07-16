using KEPABackend.DTOs.Post;
using KEPABackend.Interfaces.ControllerServices;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Mitglieder
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SpieleingabeController : ControllerBase
{
    private ISpieleingabeService SpieleingabeService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public SpieleingabeController(ISpieleingabeService spieleingabeService)
    {
        SpieleingabeService = spieleingabeService;
    }

    /// <summary>
    /// Erzeuge einen Spieltag
    /// </summary>
    /// <param name="spieltagCreate"></param>
    /// <returns>ID des Spieltages</returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="409">Spieltag existiert bereits</response>    
    [HttpPost]
    [Route("CreateSpieltag")]
    public async Task<ActionResult> CreateSpieltag(SpieltagCreate spieltagCreate)
    {
        var result = await SpieleingabeService.CreateSpieltagAsync(spieltagCreate);
        return Ok(result);
    }

    /// <summary>
    /// Spieltag beenden
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="200">Beenden erfolgreich</response>
    /// <response code="404">Spieltag existiert nicht</response>    
    [HttpPut]
    [Route("CloseSpieltag")]
    public async Task<ActionResult> CloseSpieltag(int SpieltagID)
    {
        await SpieleingabeService.CloseSpieltagAsync(SpieltagID);
        return Ok();
    }

    /// <summary>
    /// Spieltag löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="200">Löschen erfolgreich</response>
    /// <response code="404">Spieltag existiert nicht</response>  
    /// <response code="409">Spieltag in Verwendung</response>  
    [HttpDelete]
    [Route("DeleteSpieltag")]
    public async Task<ActionResult> DeleteSpieltag(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpieltagAsync(SpieltagID);
        return Ok();
    }

    /// <summary>
    /// Ermittlung des Spieltages in Bearbeitung
    /// </summary>
    /// <returns>ID und Datum des Spieltages</returns>
    [HttpGet]
    [Route("GetSpieltagInBearbeitung")]
    public async Task<ActionResult> GetSpieltagInBearbeitung()
    {
        var result = await SpieleingabeService.GetSpieltagInBearbeitung();
        return Ok(result);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er/Ratten
    /// </summary>
    /// <param name="neunerRattenCreate"></param>
    /// <returns></returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("Create9erRatten")]
    public async Task<ActionResult> Create9erRatten(NeunerRattenCreate neunerRattenCreate)
    {
        var result = await SpieleingabeService.Create9erRattenAsync(neunerRattenCreate);
        return Ok(result);
    }

    /// <summary>
    /// Speichere die 9er und Ratten
    /// </summary>
    /// <param name="neunerRattenUpdate"></param>
    /// <returns></returns>
    /// <response code="200">Update erfolgreich</response>
    /// <response code="404">Neuner/Ratten-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("Update9erRatten")]
    public async Task<ActionResult> Update9erRatten(NeunerRattenUpdate neunerRattenUpdate)
    {
        var result = await SpieleingabeService.Update9erRattenAsync(neunerRattenUpdate);
        return Ok(result);
    }

    /// <summary>
    /// Lösche einen 9er/Ratten-Eintrag
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="200">Löschen erfolgreich</response>
    /// <response code="404">Neuner/Ratten-Eintrag</response>  
    [HttpDelete]
    [Route("Delete9erRatten")]
    public async Task<ActionResult> Delete9erRatten(int SpieltagID)
    {
        await SpieleingabeService.DeleteNeunerRattenAsync(SpieltagID);
        return Ok();
    }

    /// <summary>
    /// Erzeuge eine Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennenCreate"></param>
    /// <returns></returns>
    /// <response code="200">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("Create6TageRennen")]
    public async Task<ActionResult> Create6TageRennen(Spiel6TageRennenCreate spiel6TageRennenCreate)
    {
        var result = await SpieleingabeService.CreateSpiel6TageRennenAsync(spiel6TageRennenCreate);
        return Ok(result);
    }

    /// <summary>
    /// Speichere die Runden/Punkte der Mannschaft beim 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Runden"></param>
    /// <param name="Punkte"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("Update6TageRennen")]
    public async Task<ActionResult> Update6TageRennen(int SpieltagID, int Runden, int Punkte)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche eine Mannschaft aus dem 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("Delete6TageRennen")]
    public async Task<ActionResult> Delete6TageRennen(int SpieltagID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge eine Spielerpaarung für Blitztunier
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
    /// Speichere die Punkte der Spieler
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="PunkteSpieler1"></param>
    /// <param name="PunkteSpieler2"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateBlitztunier")]
    public async Task<ActionResult> UpdateBlitztunier(int SpieltagID, int PunkteSpieler1, int PunkteSpieler2)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus dem Blitztunier
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeleteBlitztunier")]
    public async Task<ActionResult> DeleteBlitztunier(int SpieltagID)
    {
        return Ok(1);
    }

    /// <summary>
    /// Erzeuge Spielerpaarung für Meisterschaft
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
    /// Speichere die Holzzahlen der Spielerpaarung
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="HolzSpieler1"></param>
    /// <param name="HolzSpieler2"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateMeisterschaft")]
    public async Task<ActionResult> UpdateMeisterschaft(int SpieltagID, int HolzSpieler1, int HolzSpieler2)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus der Meisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeleteMeisterschaft")]
    public async Task<ActionResult> DeleteMeisterschaft(int SpieltagID)
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
    /// Speichere die Punkte der Spielerpaarung der Kombimeisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Punkte3bis8"></param>
    /// <param name="Punkte5Kugeln"></param>
    /// <param name="HinRückrunde"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateKombimeisterschaft")]
    public async Task<ActionResult> UpdateKombimeisterschaft(int SpieltagID, int Punkte3bis8, int Punkte5Kugeln, int HinRückrunde)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus der Kombimeisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeleteKombimeisterschaft")]
    public async Task<ActionResult> DeleteKombimeisterschaft(int SpieltagID)
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
    /// Speichere die Platzierung im Pokal
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Platzierung"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdatePokal")]
    public async Task<ActionResult> UpdatePokal(int SpieltagID, int Platzierung)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche den Spieler aus dem Pokal
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeletePokal")]
    public async Task<ActionResult> DeletePokal(int SpieltagID)
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

    /// <summary>
    /// Speichere die Platzierung des Spielers beim Sargkegeln
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="Platzierung"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("UpdateSargkegeln")]
    public async Task<ActionResult> UpdateSargkegeln(int SpieltagID, int Platzierung)
    {
        return Ok(1);
    }

    /// <summary>
    /// Lösche den Spieler aus dem Sargkegeln
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("DeleteSargkegeln")]
    public async Task<ActionResult> DeleteSargkegeln(int SpieltagID)
    {
        return Ok(1);
    }
}

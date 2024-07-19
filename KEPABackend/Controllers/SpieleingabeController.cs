using KEPABackend.DTOs.Input;
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
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="409">Spieltag existiert bereits</response>    
    [HttpPost]
    [Route("CreateSpieltag")]
    public async Task<ActionResult> CreateSpieltag(SpieltagCreate spieltagCreate)
    {
        var result = await SpieleingabeService.CreateSpieltagAsync(spieltagCreate);
        return Created("/", result);
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
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">Spieltag existiert nicht</response>  
    /// <response code="409">Spieltag in Verwendung</response>  
    [HttpDelete]
    [Route("DeleteSpieltag")]
    public async Task<ActionResult> DeleteSpieltag(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpieltagAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Ermittlung des Spieltages in Bearbeitung
    /// </summary>
    /// <returns>ID und Datum des Spieltages</returns>
    /// <response code="200">Spieltag gefunden</response>
    [HttpGet]
    [Route("GetSpieltagInBearbeitungAsync")]
    public async Task<ActionResult> GetSpieltagInBearbeitung()
    {
        var result = await SpieleingabeService.GetSpieltagInBearbeitungAsync();
        return Ok(result);
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er/Ratten
    /// </summary>
    /// <param name="neunerRattenCreate"></param>
    /// <returns></returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("Create9erRatten")]
    public async Task<ActionResult> Create9erRatten(NeunerRattenCreate neunerRattenCreate)
    {
        var result = await SpieleingabeService.Create9erRattenAsync(neunerRattenCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die 9er und Ratten
    /// </summary>
    /// <param name="neunerRattenUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">Neuner/Ratten-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("Update9erRatten")]
    public async Task<ActionResult> Update9erRatten(NeunerRattenUpdate neunerRattenUpdate)
    {
        var result = await SpieleingabeService.Update9erRattenAsync(neunerRattenUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche einen 9er/Ratten-Eintrag
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">Neuner/Ratten-Eintrag nicht gefunden</response>  
    [HttpDelete]
    [Route("Delete9erRatten")]
    public async Task<ActionResult> Delete9erRatten(int SpieltagID)
    {
        await SpieleingabeService.DeleteNeunerRattenAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge eine Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennenCreate"></param>
    /// <returns>ID der Entity</returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("Create6TageRennen")]
    public async Task<ActionResult> Create6TageRennen(Spiel6TageRennenCreate spiel6TageRennenCreate)
    {
        var result = await SpieleingabeService.CreateSpiel6TageRennenAsync(spiel6TageRennenCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Runden/Punkte der Mannschaft beim 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennenUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">Spiel6TageRennen-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("Update6TageRennen")]
    public async Task<ActionResult> Update6TageRennen(Spiel6TageRennenUpdate spiel6TageRennenUpdate)
    {
        var result = await SpieleingabeService.UpdateSpiel6TageRennenAsync(spiel6TageRennenUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche eine Mannschaft aus dem 6-Tage-Rennen
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">Spiel6TageRennen nicht gefunden</response>  
    [HttpDelete]
    [Route("Delete6TageRennen")]
    public async Task<ActionResult> Delete6TageRennen(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpiel6TageRennenAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge eine Spielerpaarung für Blitztunier
    /// </summary>
    /// <param name="spielBlitztunierCreate"></param>
    /// <returns>ID der Entity</returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("CreateBlitztunier")]
    public async Task<ActionResult> CreateBlitztunier(SpielBlitztunierCreate spielBlitztunierCreate)
    {
        var result = await SpieleingabeService.CreateSpielBlitztunierAsync(spielBlitztunierCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Punkte der Spieler
    /// </summary>
    /// <param name="spielBlitztunierUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">SpielBlitztunier-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("UpdateBlitztunier")]
    public async Task<ActionResult> UpdateBlitztunier(SpielBlitztunierUpdate spielBlitztunierUpdate)
    {
        var result = await SpieleingabeService.UpdateSpielBlitztunierAsync(spielBlitztunierUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus dem Blitztunier
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">SpielBlitztunier nicht gefunden</response>  
    [HttpDelete]
    [Route("DeleteBlitztunier")]
    public async Task<ActionResult> DeleteBlitztunier(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpielBlitztunierAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge Spielerpaarung für Meisterschaft
    /// </summary>
    /// <param name="spielMeisterschaftCreate"></param>
    /// <returns>ID der Entity</returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("CreateMeisterschaft")]
    public async Task<ActionResult> CreateMeisterschaft(SpielMeisterschaftCreate spielMeisterschaftCreate)
    {
        var result = await SpieleingabeService.CreateSpielMeisterschaftAsync(spielMeisterschaftCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Holzzahlen der Spielerpaarung
    /// </summary>
    /// <param name="spielMeisterschaftUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">SpielMeisterschaft-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("UpdateMeisterschaft")]
    public async Task<ActionResult> UpdateMeisterschaft(SpielMeisterschaftUpdate spielMeisterschaftUpdate)
    {
        var result = await SpieleingabeService.UpdateSpielMeisterschaftAsync(spielMeisterschaftUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus der Meisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    ///  <response code="204">Löschen erfolgreich</response>
    /// <response code="404">SpielMeister nicht gefunden</response>  
    [HttpDelete]
    [Route("DeleteMeisterschaft")]
    public async Task<ActionResult> DeleteMeisterschaft(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpielMeisterschaftAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Kombimeisterschaft
    /// </summary>
    /// <param name="spielKombimeisterschaftCreate"></param>
    /// <returns></returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("CreateKombimeisterschaft")]
    public async Task<ActionResult> CreateKombimeisterschaft(SpielKombimeisterschaftCreate spielKombimeisterschaftCreate)
    {
        var result = await SpieleingabeService.CreateSpielKombimeisterschaftAsync(spielKombimeisterschaftCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Punkte der Spielerpaarung der Kombimeisterschaft
    /// </summary>
    /// <param name="spielKombimeisterschaftUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">SpielKombimeisterschaft-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("UpdateKombimeisterschaft")]
    public async Task<ActionResult> UpdateKombimeisterschaft(SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate)
    {
        var result = await SpieleingabeService.UpdateSpielKombimeisterschaftAsync(spielKombimeisterschaftUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche die Spielerpaarung aus der Kombimeisterschaft
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    ///  <response code="204">Löschen erfolgreich</response>
    /// <response code="404">SpielKombimeisterschaft nicht gefunden</response>  
    [HttpDelete]
    [Route("DeleteKombimeisterschaft")]
    public async Task<ActionResult> DeleteKombimeisterschaft(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpielKombimeisterschaftAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Pokal
    /// </summary>
    /// <param name="spielPokalCreate"></param>
    /// <returns></returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("CreatePokal")]
    public async Task<ActionResult> CreatePokal(SpielPokalCreate spielPokalCreate)
    {
        var result = await SpieleingabeService.CreateSpielPokalAsync(spielPokalCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Platzierung im Pokal
    /// </summary>
    /// <param name="spielPokalUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">SpielPokal-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("UpdatePokal")]
    public async Task<ActionResult> UpdatePokal(SpielPokalUpdate spielPokalUpdate)
    {
        var result = await SpieleingabeService.UpdateSpielPokalAsync(spielPokalUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche den Spieler aus dem Pokal
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">SpielPokal nicht gefunden</response>  
    [HttpDelete]
    [Route("DeletePokal")]
    public async Task<ActionResult> DeletePokal(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpielPokalAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für Sargkegeln
    /// </summary>
    /// <param name="spielSargkegelnCreate"></param>
    /// <returns></returns>
    /// <response code="201">Anlegen erfolgreich</response>
    /// <response code="404">Spieltag oder Spieler existiert nicht</response>  
    /// <response code="409">Eintrag bereits vorhanden</response>  
    [HttpPost]
    [Route("CreateSargkegeln")]
    public async Task<ActionResult> CreateSargkegeln(SpielSargkegelnCreate spielSargkegelnCreate)
    {
        var result = await SpieleingabeService.CreateSpielSargkegelnAsync(spielSargkegelnCreate);
        return Created("/", result);
    }

    /// <summary>
    /// Speichere die Platzierung des Spielers beim Sargkegeln
    /// </summary>
    /// <param name="spielSargkegelnUpdate"></param>
    /// <returns></returns>
    /// <response code="205">Update erfolgreich</response>
    /// <response code="400">Validation Error</response>
    /// <response code="404">SpielPokal-Eintrag, Spieltag oder Spieler existiert nicht</response>  
    [HttpPut]
    [Route("UpdateSargkegeln")]
    public async Task<ActionResult> UpdateSargkegeln(SpielSargkegelnUpdate spielSargkegelnUpdate)
    {
        var result = await SpieleingabeService.UpdateSpielSargkegelnAsync(spielSargkegelnUpdate);
        //return Ok(result);
        return StatusCode(StatusCodes.Status205ResetContent, result);
    }

    /// <summary>
    /// Lösche den Spieler aus dem Sargkegeln
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns></returns>
    /// <response code="204">Löschen erfolgreich</response>
    /// <response code="404">SpielSargkegeln nicht gefunden</response>  
    [HttpDelete]
    [Route("DeleteSargkegeln")]
    public async Task<ActionResult> DeleteSargkegeln(int SpieltagID)
    {
        await SpieleingabeService.DeleteSpielSargkegelnAsync(SpieltagID);
        //return Ok();
        return NoContent();
    }
}

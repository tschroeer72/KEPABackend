using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface 
/// </summary>
public interface ISpieleingabeService
{
    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltagCreate"></param>
    /// <returns>ID des neuen SPieltages</returns>
    Task<EntityID> CreateSpieltagAsync(SpieltagCreate spieltagCreate);

    /// <summary>
    /// Spieltag abschließen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task CloseSpieltagAsync(int SpieltagID);

    /// <summary>
    /// Spieltag löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpieltagAsync(int SpieltagID);

    /// <summary>
    /// Hole den Spieltag der in Bearbeitung ist
    /// </summary>
    /// <returns>ID und Datum des Spieltag</returns>
    Task<AktuellerSpieltag?> GetSpieltagInBearbeitungAsync();

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er und Ratten
    /// </summary>
    /// <param name="neunerRattenCreate"></param>
    /// <returns></returns>
    Task<EntityID> Create9erRattenAsync(NeunerRattenCreate neunerRattenCreate);

    /// <summary>
    /// Aktualisiere NeunerRatten Eintität
    /// </summary>
    /// <param name="neunerRattenUpdate"></param>
    /// <returns></returns>
    Task<NeunerRatten> Update9erRattenAsync(NeunerRattenUpdate neunerRattenUpdate);
    
    /// <summary>
    /// Neuner/Ratten löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteNeunerRattenAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennenCreate"></param>
    /// <returns></returns>
    Task<EntityID> CreateSpiel6TageRennenAsync(Spiel6TageRennenCreate spiel6TageRennenCreate);

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spiel6TageRennenUpdate"></param>
    /// <returns></returns>
    Task<Spiel6TageRennen> UpdateSpiel6TageRennenAsync(Spiel6TageRennenUpdate spiel6TageRennenUpdate);

    /// <summary>
    /// Mannschaft auf 6-Tage-Rennen löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpiel6TageRennenAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Eintrag für Blitztunier
    /// </summary>
    /// <param name="spielBlitztunierCreate"></param>
    /// <returns></returns>
    Task<EntityID> CreateSpielBlitztunierAsync(SpielBlitztunierCreate spielBlitztunierCreate);

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spielBlitztunierUpdate"></param>
    /// <returns></returns>
    Task<SpielBlitztunier> UpdateSpielBlitztunierAsync(SpielBlitztunierUpdate spielBlitztunierUpdate);

    /// <summary>
    /// Paarung aus Blitztunier löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielBlitztunierAsync(int SpieltagID);

    /// <summary>
    /// Erzeuge Eintrag für Meisterschaft
    /// </summary>
    /// <param name="spielMeisterschaftCreate"></param>
    /// <returns></returns>
    Task<EntityID> CreateSpielMeisterschaftAsync(SpielMeisterschaftCreate spielMeisterschaftCreate);

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spielMeisterschaftUpdate"></param>
    /// <returns></returns>
    Task<SpielMeisterschaft> UpdateSpielMeisterschaftAsync(SpielMeisterschaftUpdate spielMeisterschaftUpdate);

    /// <summary>
    /// Paarung aus Meisterschaft löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpielMeisterschaftAsync(int SpieltagID);
}

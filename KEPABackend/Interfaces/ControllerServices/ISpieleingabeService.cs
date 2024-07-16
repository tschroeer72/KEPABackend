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
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    Task DeleteSpieltagAsync(int SpieltagID);

    /// <summary>
    /// Hole den Spieltag der in Bearbeitung ist
    /// </summary>
    /// <returns>ID und Datum des Spieltag</returns>
    Task<AktuellerSpieltag?> GetSpieltagInBearbeitung();

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
}

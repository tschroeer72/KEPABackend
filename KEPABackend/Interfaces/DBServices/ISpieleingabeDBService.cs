using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface 
/// </summary>
public interface ISpieleingabeDBService
{
    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltag"></param>
    /// <returns>ID des neuen Spieltages</returns>
    Task<int> CreateSpieltagAsync(TblSpieltag spieltag);

    /// <summary>
    /// Überprüfe, ob Spieltag bereits existiert
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>NULL oder ID des Spieltages</returns>
    Task<int?> CheckSpieltagExistingAsync(int MeisterschaftsID, DateTime Spieltag);

    /// <summary>
    /// Hole den Spieltag der ID
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns>NULL oder Spieltag</returns>
    Task<TblSpieltag?> GetSpieltagByIDAsync(int SpieltagID);

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
    Task<AktuellerSpieltag> GetSpieltagInBearbeitung();
}

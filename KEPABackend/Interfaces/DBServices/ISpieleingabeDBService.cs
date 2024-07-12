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
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>ID des neuen Spieltages</returns>
    Task<int> CreateSpieltagAsync(TblSpieltag spieltag);

    /// <summary>
    /// Überprüfe, ob Spieltag bereits existiert
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>NULL oder ID des Spieltages</returns>
    Task<int?> CheckSpieltagExistingAsync(int MeisterschaftsID, DateTime Spieltag);
}

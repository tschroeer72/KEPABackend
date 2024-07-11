using KEPABackend.DTOs.Get;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface IMeisterschaftsDBService
/// </summary>
public interface IMeisterschaftDBService
{
    /// <summary>
    /// Service CreateMeisterschaftAsync
    /// </summary>
    /// <param name="meisterschaft"></param>
    /// <returns>ID der neuen Entität</returns>
    Task<int> CreateMeisterschaftAsync(TblMeisterschaften meisterschaft);

    /// <summary>
    /// Speichert die Änderungen in der DB
    /// </summary>
    /// <returns>void</returns>
    Task UpdateMeisterschaftAsync();

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    Task<List<Meisterschaft>> GetAllMeisterschaften();

    /// <summary>
    /// Service GetMeisterschaftByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaft mit der ID </returns>
    Task<TblMeisterschaften?> GetMeisterschaftByIDAsync(int ID);

    /// <summary>
    /// Teilnehmer zu einer Meisterschaft hinzufügen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    Task AddTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID);

    /// <summary>
    /// Teilnehmer aus einer Meisterschaft löschen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    Task DeleteTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID);
}

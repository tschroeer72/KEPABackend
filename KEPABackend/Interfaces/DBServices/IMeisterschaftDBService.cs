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
    Task<long> CreateMeisterschaftAsync(TblMeisterschaften meisterschaft);

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
    Task<TblMeisterschaften?> GetMeisterschaftByIDAsync(long ID);
}

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
}

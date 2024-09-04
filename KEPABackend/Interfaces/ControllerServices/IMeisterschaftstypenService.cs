using KEPABackend.DTOs.Output;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface für MeisterschaftstypenService
/// </summary>
public interface IMeisterschaftstypenService
{
    /// <summary>
    /// Service GetAllMeisterschaftstypenAsync
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypenAsync();

    /// <summary>
    /// Suche Meisterschaftstyp mit der ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp oder null</returns>
    Task<Meisterschaftstypen> GetMeisterschaftstypByIDAsync(int ID);
}

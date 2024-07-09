using KEPABackend.DTOs.Get;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces;

/// <summary>
/// Interface IMeisterschaftstypenDBService
/// </summary>
public interface IMeisterschaftstypenDBService
{
    Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypenAsync();
    Task<Meisterschaftstypen?> GetMeisterschaftstypByIDAsync(int ID);
}

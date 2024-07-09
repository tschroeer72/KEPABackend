using KEPABackend.DTOs.Get;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;

namespace KEPABackend.Services;

/// <summary>
/// Service für MEisterschaftstypen
/// </summary>
public class MeisterschaftstypService
{
    private IMeisterschaftstypenDBService MeisterschaftstypenDBService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftstypenDBService"></param>
    public MeisterschaftstypService(IMeisterschaftstypenDBService meisterschaftstypenDBService )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
    }

    /// <summary>
    /// Liste aller Meisterschaftstypen
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    public async Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypen()
    {
        return await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
    }

    /// <summary>
    /// Suche Meisterschaftstyp mit der ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp oder null</returns>
    /// <exception cref="MeisterschaftstypNotFoundException"></exception>
    public async Task<Meisterschaftstypen?> GetMeisterschaftstypByID(int ID)
    {
        Meisterschaftstypen? mt = await MeisterschaftstypenDBService.GetMeisterschaftstypByIDAsync(ID);

        if (mt == null)
        {
            throw new MeisterschaftstypNotFoundException();
        }

        return mt;
    }
}

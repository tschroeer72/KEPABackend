using KEPABackend.DTOs.Get;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;

namespace KEPABackend.Services;

/// <summary>
/// Service für MEisterschaftstypen
/// </summary>
public class MeisterschaftstypenService : IMeisterschaftstypenService
{
    private IMeisterschaftstypenDBService MeisterschaftstypenDBService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="meisterschaftstypenDBService"></param>
    public MeisterschaftstypenService(IMeisterschaftstypenDBService meisterschaftstypenDBService )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
    }

    /// <summary>
    /// Liste aller Meisterschaftstypen
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    public async Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypenAsync()
    {
        return await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
    }

    /// <summary>
    /// Suche Meisterschaftstyp mit der ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp oder null</returns>
    /// <exception cref="MeisterschaftstypNotFoundException"></exception>
    public async Task<Meisterschaftstypen> GetMeisterschaftstypByIDAsync(int ID)
    {
        Meisterschaftstypen? mt = await MeisterschaftstypenDBService.GetMeisterschaftstypByIDAsync(ID);

        if (mt == null)
        {
            throw new MeisterschaftstypNotFoundException();
        }

        return mt;
    }
}

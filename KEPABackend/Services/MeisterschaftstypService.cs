using KEPABackend.DTOs.Get;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;

namespace KEPABackend.Services;

public class MeisterschaftstypService
{
    public IMeisterschaftstypenDBService MeisterschaftstypenDBService { get; }

    public MeisterschaftstypService(IMeisterschaftstypenDBService meisterschaftstypenDBService )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
    }

    public async Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypen()
    {
        return await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
    }

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

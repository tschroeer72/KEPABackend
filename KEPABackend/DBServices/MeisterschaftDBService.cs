using KEPABackend.Interfaces;
using KEPABackend.Modell;

namespace KEPABackend.DBServices;

/// <summary>
/// DB Service für TblMeisterschaften
/// </summary>
public class MeisterschaftDBService : IMeisterschaftsDBService
{
    private ApplicationDbContext DbContext { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext"></param>
    public MeisterschaftDBService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Anlegen der Meisterschaft in der DB
    /// </summary>
    /// <param name="meisterschaft"></param>
    /// <returns>ID der neuen Meisterschaft</returns>
    public async Task<long> CreateMeisterschaftAsync(TblMeisterschaften meisterschaft)
    {
        await DbContext.TblMeisterschaftens.AddAsync(meisterschaft);
        await DbContext.SaveChangesAsync();
        long lngID = meisterschaft.Id;
        return lngID;
    }
}

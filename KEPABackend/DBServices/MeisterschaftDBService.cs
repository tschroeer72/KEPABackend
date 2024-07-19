using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

/// <summary>
/// DB Service für TblMeisterschaften
/// </summary>
public class MeisterschaftDBService : IMeisterschaftDBService
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
    public async Task<int> CreateMeisterschaftAsync(TblMeisterschaften meisterschaft)
    {
        await DbContext.TblMeisterschaftens.AddAsync(meisterschaft);
        await DbContext.SaveChangesAsync();
        int lngID = meisterschaft.Id;
        return lngID;
    }

    /// <summary>
    /// Speichert die Änderungen in der DB
    /// </summary>
    /// <returns>void</returns>
    public async Task UpdateMeisterschaftAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Service GetMeisterschaftByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaft mit der ID </returns>
    public async Task<TblMeisterschaften?> GetMeisterschaftByIDAsync(int ID)
    {
        var meisterschaft = await DbContext.TblMeisterschaftens
            .Where(w => w.Id == ID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        return meisterschaft;
    }

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    public async Task<List<Meisterschaft>> GetAllMeisterschaften()
    {
        var lstMeisterschaften = await DbContext.TblMeisterschaftens
            .Select(s => new Meisterschaft()
            {
                ID = s.Id,
                Bezeichnung = s.Bezeichnung,
                Beginn = s.Beginn,
                Ende = s.Ende,
                MeisterschaftstypID = s.MeisterschaftstypId,
                Aktiv = s.Aktiv,
                Bemerkungen = s.Bemerkungen
            })
            .ToListAsync();

        return lstMeisterschaften;
    }

    /// <summary>
    /// Teilnehmer zu einer Meisterschaft hinzufügen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    public async Task AddTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID)
    {
        TblTeilnehmer objTeilnehmer = new TblTeilnehmer();
        objTeilnehmer.MeisterschaftsId = (int)MeisterschaftID;
        objTeilnehmer.SpielerId = (int)TeilnehmerID;
        await DbContext.TblTeilnehmers.AddAsync(objTeilnehmer);
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Teilnehmer aus einer Meisterschaft löschen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    public async Task DeleteTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID)
    {
        TblTeilnehmer? teilnehmer = await DbContext.TblTeilnehmers
            .Where(w => w.MeisterschaftsId == MeisterschaftID && w.SpielerId == TeilnehmerID)
            .SingleOrDefaultAsync();

        if(teilnehmer != null)
        {
            DbContext.TblTeilnehmers.Remove(teilnehmer);
            await DbContext.SaveChangesAsync();
        }
    }
}

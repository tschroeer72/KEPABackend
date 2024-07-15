using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

/// <summary>
/// DB Service für die Spieleingabe
/// </summary>
public class SpieleingabeDBService : ISpieleingabeDBService
{
    private readonly ApplicationDbContext DbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext"></param>
    public SpieleingabeDBService(ApplicationDbContext dbContext)
    {
        this.DbContext = dbContext;
    }

    /// <summary>
    /// Überprüfe, ob Spieltag bereits existiert
    /// </summary>
    /// <param name="MeisterschaftsID"></param>
    /// <param name="Spieltag"></param>
    /// <returns>NULL oder ID des Spieltages</returns>
    public async Task<int?> CheckSpieltagExistingAsync(int MeisterschaftsID, DateTime Spieltag)
    {
        var checkSpieltag = await DbContext.TblSpieltags
                                    .Where(w => w.MeisterschaftsId == MeisterschaftsID && w.Spieltag == Spieltag)
                                    .Select(s => s)
                                    .SingleOrDefaultAsync();

        return checkSpieltag?.Id;
    }

    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltag"></param>
    /// <returns>ID des neuen Spieltages</returns>
    public async Task<int> CreateSpieltagAsync(TblSpieltag spieltag)
    {
        var tmp = DbContext.TblSpieltags
            .Where(w => w.InBearbeitung != 0)
            .Select(s => s)
            .AsEnumerable()
            .ToList();

        foreach (var item in tmp) 
        {
            item.InBearbeitung = 0;
        }
        //await DbContext.SaveChangesAsync();

        spieltag.InBearbeitung = 1;
        await DbContext.TblSpieltags.AddAsync(spieltag);
        await DbContext.SaveChangesAsync();
        return spieltag.Id;
    }

    /// <summary>
    /// Spieltag abschließen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task CloseSpieltagAsync(int SpieltagID)
    {
        var spieltag = await DbContext.TblSpieltags
            .Where(w => w.Id == SpieltagID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        if (spieltag != null)
        {
            spieltag.InBearbeitung = 0;
            await DbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Hole den Spieltag der ID
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <returns>NULL oder Spieltag</returns>
    public async Task<TblSpieltag?> GetSpieltagByIDAsync(int SpieltagID)
    {
        var spieltag = await DbContext.TblSpieltags
            .Where(w => w.Id == SpieltagID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        return spieltag;
    }

    /// <summary>
    /// Spieltag löschen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteSpieltagAsync(int SpieltagID)
    {
        var spieltag = await DbContext.TblSpieltags
            .Where(w => w.Id == SpieltagID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        if (spieltag != null)
        {
            try
            {
                DbContext.TblSpieltags.Remove(spieltag);
                await DbContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                throw new SpieltagInUseException();
            }
        }
    }

    /// <summary>
    /// Hole den Spieltag der in Bearbeitung ist
    /// </summary>
    /// <returns>ID und Datum des Spieltag</returns>
    public async Task<AktuellerSpieltag?> GetSpieltagInBearbeitung()
    {
        AktuellerSpieltag objSpieltag = new();

        var spieltag = await DbContext.TblSpieltags
                                    .Where(w => w.InBearbeitung == 1)
                                    .Select(s => new AktuellerSpieltag()
                                    {
                                        ID = s.Id,
                                        Spieltag = s.Spieltag
                                    })
                                    .SingleOrDefaultAsync();

        if (spieltag != null)
        {
            objSpieltag = spieltag;
        }
        else
        {
            objSpieltag.ID = -1;
        }
        return objSpieltag;
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er und Ratten
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns></returns>
    public async Task<NeunerRatten> Create9erRattenAsync(int SpieltagID, int SpielerID)
    {
        Tbl9erRatten objNR = new();
        objNR.SpieltagId = SpieltagID;
        objNR.SpielerId = SpielerID;
        objNR.Neuner = 0;
        objNR.Ratten = 0;

        await DbContext.Tbl9erRattens.AddAsync(objNR);
        await DbContext.SaveChangesAsync();

        NeunerRatten objResult = new()
        {
            ID = objNR.Id,
            SpieltagID = objNR.SpieltagId,
            SpielerID = objNR.SpielerId,
            Neuner = objNR.Neuner,
            Ratten = objNR.Ratten
        };

        return objResult;
    }

    /// <summary>
    /// Überprüfe, ob es bereits einen Eintrag für diesen Spieltag für diesen Spieler gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns>NULL oder ID der Entität</returns>
    public async Task<int?> Check9erRattenExistingAsync(int SpieltagID, int SpielerID)
    {
        var check9erRatten = await DbContext.Tbl9erRattens
                                    .Where(w => w.SpieltagId == SpieltagID && w.SpielerId == SpielerID)
                                    .Select(s => s)
                                    .SingleOrDefaultAsync();

        return check9erRatten?.Id;
    }
}

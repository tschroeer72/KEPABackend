﻿using KEPABackend.DTOs.Get;
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
            catch(DbUpdateException)
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
    /// <param name="neunerRatten"></param>
    /// <returns></returns>
    public async Task<int> Create9erRattenAsync(Tbl9erRatten neunerRatten)
    {
        neunerRatten.Neuner = 0;
        neunerRatten.Ratten = 0;

        await DbContext.Tbl9erRattens.AddAsync(neunerRatten);
        await DbContext.SaveChangesAsync();

        return neunerRatten.Id;
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

    /// <summary>
    /// Aktualisiere NeunerRatten Entität
    /// </summary>
    /// <returns></returns>
    public async Task Update9erRattenAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Hole die NeunerRatten-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>9ner/Ratten-Entität</returns>
    public async Task<Tbl9erRatten?> Get9erRattenByID(int ID)
    {
        var neunerRatten = await DbContext.Tbl9erRattens
            .Where(w => w.Id == ID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        return neunerRatten;
    }

    /// <summary>
    /// Neuner/Ratten löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteNeunerRattenAsync(int SpieltagID)
    {
        var neunerRatten = await DbContext.Tbl9erRattens
            .Where(w => w.Id == SpieltagID)
            .Select(s => s)
            .SingleAsync();

        DbContext.Tbl9erRattens.Remove(neunerRatten);
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Erzeuge Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennen"></param>
    /// <returns></returns>
    public async Task<int> CreateSpiel6TageRennenAsync(TblSpiel6TageRennen spiel6TageRennen)
    {
        spiel6TageRennen.Runden = 0;
        spiel6TageRennen.Punkte = 0;

        await DbContext.TblSpiel6TageRennens.AddAsync(spiel6TageRennen);
        await DbContext.SaveChangesAsync();
        return spiel6TageRennen.Id;
    }

    /// <summary>
    /// Überprüfe, ob es bereits diese Mannschaft für diesen Spieltag gibt
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID1"></param>
    /// <param name="SpielerID2"></param>
    /// <returns>NULL oder ID der Entität</returns>
    public async Task<int?> CheckSpiel6TageRennenExistingAsync(int SpieltagID, int SpielerID1, int SpielerID2)
    {
        var check6TageRenne = await DbContext.TblSpiel6TageRennens
                                    .Where(w => w.SpieltagId == SpieltagID && w.SpielerId1 == SpielerID1 && w.SpielerId2 == SpielerID2)
                                    .Select(s => s)
                                    .SingleOrDefaultAsync();

        return check6TageRenne?.Id;
    }

    /// <summary>
    /// Aktualisiere Spiel6TagreRennen Entität
    /// </summary>
    /// <returns></returns>
    public async Task UpdateSpiel6TageRennenAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Hole die Spiel6TageRennen-Entität
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>NULL oder Spiel6TageRennen-Entität</returns>
    public async Task<TblSpiel6TageRennen?> GetSpiel6TagreRennenByID(int ID)
    {
        var spiel6TageRennen = await DbContext.TblSpiel6TageRennens
            .Where(w => w.Id == ID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        return spiel6TageRennen;
    }
}

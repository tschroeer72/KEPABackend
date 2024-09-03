using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Models;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

/// <summary>
/// DB Service für TblMitglieder
/// </summary>
public class MitgliederDBService : IMitgliederDBService
{
    private ApplicationDbContext DbContext { get; }

    /// <summary>
    /// Constuctur
    /// </summary>
    /// <param name="dbContext"></param>
    public MitgliederDBService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitglied"></param>
    /// <returns>ID der neuen Entität</returns>
    public async Task<int> CreateMitgliederAsync(TblMitglieder mitglied)
    {
        
        await DbContext.TblMitglieders.AddAsync(mitglied);
        await DbContext.SaveChangesAsync();
        int lngID = mitglied.Id;
        return lngID;
    }

    /// <summary>
    /// Speichert die Änderungen in der DB
    /// </summary>
    /// <returns>void</returns>
    public async Task UpdateMitgliederAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <param name="bAktiv">true (Default) = nur aktive Mitglieder; false = alle Mitglieder</param>
    /// <returns>Liste aller Mitglieder</returns>
    public async Task<List<Mitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true)
    {
        var lst = await DbContext.TblMitglieders
            .Where(w => bAktiv ? w.Ehemaliger == 0 : w.Ehemaliger == 1 || w.Ehemaliger == 0)
            .Select(s => new Mitgliederliste
            {
                ID = s.Id,
                Anrede = s.Anrede,
                Vorname = s.Vorname,
                Spitzname = s.Spitzname,
                Nachname = s.Nachname,
                Straße = s.Straße,
                PLZ = s.Plz,
                Ort = s.Ort,
                Geburtsdatum = s.Geburtsdatum,
                MitgliedSeit = s.MitgliedSeit,
                PassivSeit = s.PassivSeit,
                AusgeschiedenAm = s.AusgeschiedenAm,
                Ehemaltiger = s.Ehemaliger,
                Email = s.Email,
                TelefonFirma = s.TelefonFirma,
                TelefonPrivat = s.TelefonPrivat,
                TelefonMobil = s.TelefonMobil,
                Fax = s.Fax,
                Bemerkungen = s.Bemerkungen,
                Notizen = s.Notizen
            }).ToListAsync();

        return lst;
    }

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    public async Task<TblMitglieder?> GetMitgliedByIDAsync(int ID)
    {
        var mitglied = await DbContext.TblMitglieders
            .Where(w => w.Id == ID)
            .Select(s => s)
            .SingleOrDefaultAsync();

        return mitglied;
    }
}

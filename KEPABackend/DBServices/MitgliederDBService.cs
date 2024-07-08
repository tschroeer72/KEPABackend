﻿using AutoMapper;
using FluentValidation;
using KEPABackend.DTOs;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;

namespace KEPABackend.DBServices;

public class MitgliederDBService : IMitgliederDBService
{
    public ApplicationDbContext DbContext { get; }

    /// <summary>
    /// Constuctur
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="mitgliederCreateValidator"></param>
    /// <param name="mapper"></param>
    public MitgliederDBService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns>ID der neuen Entität</returns>
    public async Task<long> CreateMitgliederAsync(TblMitglieder mitglied)
    {
        
        await DbContext.TblMitglieders.AddAsync(mitglied);
        await DbContext.SaveChangesAsync();
        long lngID = mitglied.Id;
        return lngID;
    }

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <returns>Liste aller Mitglieder</returns>
    public async Task<List<GetMitgliederliste>> GetAllMitgliederAsync()
    {
        var lst = await DbContext.TblMitglieders
            .Select(s => new GetMitgliederliste
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
    public async Task<GetMitgliederliste?> GetMitgliedByIDAsync(int ID)
    {
        var mitglied = await DbContext.TblMitglieders
            .Where(w => w.Id == ID)
            .Select(s => new GetMitgliederliste
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
                Email = s.Email,
                TelefonFirma = s.TelefonFirma,
                TelefonPrivat = s.TelefonPrivat,
                TelefonMobil = s.TelefonMobil,
                Fax = s.Fax,
                Bemerkungen = s.Bemerkungen,
                Notizen = s.Notizen
            }).SingleOrDefaultAsync();

        return mitglied;
    }
}

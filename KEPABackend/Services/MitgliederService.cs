using AutoMapper;
using FluentValidation;
using KEPABackend.Exceptions;
using KEPABackend.Models;
using KEPABackend.DBServices;
using KEPABackend.Validations;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Interfaces.ControllerServices;
using System.Text;
using System.Security.Cryptography;

namespace KEPABackend.Services;

/// <summary>
/// Service für Mitglieder
/// </summary>
public class MitgliederService : IMitgliederService
{
    private IMitgliederDBService MitgliederDBService { get; }
    private IMapper Mapper { get; }
    private MitgliederCreateValidator MitgliederCreateValidator { get; }
    private MitgliederUpdateValidator MitgliederUpdateValidator { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mitgliederDBService"></param>
    /// <param name="mapper"></param>
    /// <param name="mitgliederCreateValidator"></param>
    /// <param name="mitgliederUpdateValidator"></param>
    public MitgliederService(IMitgliederDBService mitgliederDBService, IMapper mapper, MitgliederCreateValidator mitgliederCreateValidator, MitgliederUpdateValidator mitgliederUpdateValidator)
    {
        MitgliederDBService = mitgliederDBService;
        Mapper = mapper;
        MitgliederCreateValidator = mitgliederCreateValidator;
        MitgliederUpdateValidator = mitgliederUpdateValidator;
    }

    
    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns>ID der neuen Entität</returns>
    public async Task<EntityID> CreateMitgliederAsync(MitgliedCreate mitgliedCreate)
    {
        try
        {
            await MitgliederCreateValidator.ValidateAndThrowAsync(mitgliedCreate);
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            throw;
        }

        var mitglied = Mapper.Map<TblMitglieder>(mitgliedCreate);
        int intID = await MitgliederDBService.CreateMitgliederAsync(mitglied);
        EntityID entityID = new() { ID = intID };
        return entityID;
    }

    /// <summary>
    /// Service UpdateMitglied
    /// </summary>
    /// <param name="mitgliedUpdate"></param>
    /// <returns>Geänderte Entity</returns>
    /// <exception cref="MitgliedNotFoundException"></exception>
    public async Task<Mitgliederliste> UpdateMitgliederAsync(MitgliedUpdate mitgliedUpdate)
    {
        try
        {
            await MitgliederUpdateValidator.ValidateAndThrowAsync(mitgliedUpdate);
        }
        catch (ValidationException)
        {
            throw;
        }

        TblMitglieder? mitglied = await MitgliederDBService.GetMitgliedByIDAsync(mitgliedUpdate.ID) ?? throw new MitgliedNotFoundException();

        if (!string.IsNullOrEmpty(mitgliedUpdate.Password))
        {
            mitgliedUpdate.Password = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(mitgliedUpdate.Password)));
        }

        Mapper.Map(mitgliedUpdate, mitglied);
        await MitgliederDBService.UpdateMitgliederAsync();

        var updatedMitglied = new Mitgliederliste()
        {
            ID = mitglied.Id,
            Anrede = mitglied.Anrede,
            Vorname = mitglied.Vorname,
            Spitzname = mitglied.Spitzname,
            Nachname = mitglied.Nachname,
            Straße = mitglied.Straße,
            PLZ = mitglied.Plz,
            Ort = mitglied.Ort,
            Geburtsdatum = mitglied.Geburtsdatum,
            MitgliedSeit = mitglied.MitgliedSeit,
            PassivSeit = mitglied.PassivSeit,
            AusgeschiedenAm = mitglied.AusgeschiedenAm,
            Ehemaltiger = mitglied.Ehemaliger,
            Email = mitglied.Email,
            TelefonFirma = mitglied.TelefonFirma,
            TelefonPrivat = mitglied.TelefonPrivat,
            TelefonMobil = mitglied.TelefonMobil,
            Fax = mitglied.Fax,
            Bemerkungen = mitglied.Bemerkungen,
            Notizen = mitglied.Notizen,
            Login = mitglied.Login,
            Password = mitglied.Password
        };
        return updatedMitglied;
    }

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <param name="bAktiv"> true (Default) = nur aktive Mitglieder; false = alle Mitglieder</param>
    /// <returns>Liste aller Mitglieder</returns>
    public async Task<List<Mitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true)
    {
        return await MitgliederDBService.GetAllMitgliederAsync(bAktiv);
    }

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    public async Task<Mitgliederliste> GetMitgliedByIDAsync(int ID)
    {

        TblMitglieder? mitglied = await MitgliederDBService.GetMitgliedByIDAsync(ID) ?? throw new MitgliedNotFoundException();
        var result = new Mitgliederliste()
        {
            ID = mitglied.Id,
            Anrede = mitglied.Anrede,
            Vorname = mitglied.Vorname,
            Spitzname = mitglied.Spitzname,
            Nachname = mitglied.Nachname,
            Straße = mitglied.Straße,
            PLZ = mitglied.Plz,
            Ort = mitglied.Ort,
            Geburtsdatum = mitglied.Geburtsdatum,
            MitgliedSeit = mitglied.MitgliedSeit,
            PassivSeit = mitglied.PassivSeit,
            AusgeschiedenAm = mitglied.AusgeschiedenAm,
            Ehemaltiger = mitglied.Ehemaliger,
            Email = mitglied.Email,
            TelefonFirma = mitglied.TelefonFirma,
            TelefonPrivat = mitglied.TelefonPrivat,
            TelefonMobil = mitglied.TelefonMobil,
            Fax = mitglied.Fax,
            Bemerkungen = mitglied.Bemerkungen,
            Notizen = mitglied.Notizen,
            Login = mitglied.Login,
            Password = mitglied.Password
        };
        return result;
    }

    /// <summary>
    /// Überprüfung, ob die Credentails korrekt sind
    /// </summary>
    /// <param name="sUsername"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    public async Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword)
    {
        return await MitgliederDBService.AreCredentialsCorrectAsync(sUsername, sPassword);
    }
}

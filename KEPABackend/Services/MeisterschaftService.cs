using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using KEPABackend.Validations;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Services;

/// <summary>
/// Service für MEisterschaften
/// </summary>
public class MeisterschaftService : IMeisterschaftService
{
    private IMeisterschaftstypenDBService MeisterschaftstypenDBService { get; }
    private IMeisterschaftDBService MeisterschaftDBService { get; }
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator { get; }
    private MeisterschaftUpdateValidator MeisterschaftUpdateValidator { get; }
    private IMitgliederDBService MitgliederDBService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftService(
        IMeisterschaftstypenDBService meisterschaftstypenDBService,
        IMeisterschaftDBService meisterschaftsDBService, 
        IMapper Mapper, 
        MeisterschaftCreateValidator meisterschaftCreateValidator,
        MeisterschaftUpdateValidator meisterschaftUpdateValidator,
        IMitgliederDBService mitgliederDBService
        )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
        MeisterschaftDBService = meisterschaftsDBService;
        this.Mapper = Mapper;
        MeisterschaftCreateValidator = meisterschaftCreateValidator;
        MeisterschaftUpdateValidator = meisterschaftUpdateValidator;
        MitgliederDBService = mitgliederDBService;
    }

    /// <summary>
    /// Meisterschaft anlegen
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>ID der neuen Meisterschaft</returns>
    public async Task<EntityID> CreateMeisterschaftAsync(MeisterschaftCreate meisterschaftCreate)
    {
        try
        {
            await MeisterschaftCreateValidator.ValidateAndThrowAsync(meisterschaftCreate);
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            throw;
        }

        List<Meisterschaftstypen> lstMT = await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
        Meisterschaftstypen? find = lstMT.Find(f => f.ID == meisterschaftCreate.MeisterschaftstypID);
        if (find == null)
        {
            throw new MeisterschaftstypNotFoundException();
        }

        var meisterschaft = Mapper.Map<TblMeisterschaften>(meisterschaftCreate);
        int intID = await MeisterschaftDBService.CreateMeisterschaftAsync(meisterschaft);
        EntityID entityID = new() { ID = intID };
        return entityID;
    }

    /// <summary>
    /// Service Update Meisterschaft
    /// </summary>
    /// <param name="meisterschaftUpdate"></param>
    /// <returns>Geänderte Entity</returns>
    public async Task<Meisterschaft> UpdateMeisterschaftAsync(MeisterschaftUpdate meisterschaftUpdate)
    {
        try
        {
            await MeisterschaftUpdateValidator.ValidateAndThrowAsync(meisterschaftUpdate);
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            throw;
        }

        TblMeisterschaften? meisterschaft = await MeisterschaftDBService.GetMeisterschaftByIDAsync(meisterschaftUpdate.ID) ?? throw new MeisterschaftNotFoundException();

        List<Meisterschaftstypen> lstMT = await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
        Meisterschaftstypen? find = lstMT.Find(f => f.ID == meisterschaftUpdate.MeisterschaftstypID);
        if (find == null)
        {
            throw new MeisterschaftstypNotFoundException();
        }

        Mapper.Map(meisterschaftUpdate, meisterschaft);
        await MeisterschaftDBService.UpdateMeisterschaftAsync();

        var updatedMeisterschaft = new Meisterschaft()
        {
            ID = meisterschaft.Id,
            Bezeichnung = meisterschaft.Bezeichnung,
            Beginn = meisterschaft.Beginn,
            Ende = meisterschaft.Ende,
            MeisterschaftstypID = meisterschaft.MeisterschaftstypId,
            Aktiv = meisterschaft.Aktiv,
            Bemerkungen = meisterschaft.Bemerkungen
        };
        return updatedMeisterschaft;
    }

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    public async Task<List<Meisterschaft>> GetAllMeisterschaftenAsync()
    {
        return await MeisterschaftDBService.GetAllMeisterschaften();
    }

    /// <summary>
    /// Rückgabe einer bestimmten Meisterschaft
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task<Meisterschaft> GetMeisterschaftByIDAsync(int ID)
    {
        TblMeisterschaften? meisterschaft = await MeisterschaftDBService.GetMeisterschaftByIDAsync(ID) ?? throw new MeisterschaftNotFoundException();
        var result = new Meisterschaft()
        {
            ID = meisterschaft.Id,
            Bezeichnung = meisterschaft.Bezeichnung,
            Beginn = meisterschaft.Beginn,
            Ende = meisterschaft.Ende,
            MeisterschaftstypID = meisterschaft.MeisterschaftstypId,
            Aktiv = meisterschaft.Aktiv,
            Bemerkungen = meisterschaft.Bemerkungen
        };
        return result;
    }

    /// <summary>
    /// Teilnehmer zu einer Meisterschaft hinzufügen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    public async Task AddTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID)
    {
        TblMeisterschaften? meisterschaft = await MeisterschaftDBService.GetMeisterschaftByIDAsync(MeisterschaftID) ?? throw new MeisterschaftNotFoundException();

        TblMitglieder? mitglied = await MitgliederDBService.GetMitgliedByIDAsync(TeilnehmerID) ?? throw new MitgliedNotFoundException();

        await MeisterschaftDBService.AddTeilnehmerAsync(MeisterschaftID, TeilnehmerID);
        return; 
    }

    /// <summary>
    /// Teilnehmer aus einer Meisterschaft löschen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    public async Task DeleteTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID)
    {
        TblMeisterschaften? meisterschaft = await MeisterschaftDBService.GetMeisterschaftByIDAsync(MeisterschaftID) ?? throw new MeisterschaftNotFoundException();

        TblMitglieder? mitglied = await MitgliederDBService.GetMitgliedByIDAsync(TeilnehmerID) ?? throw new MitgliedNotFoundException();

        await MeisterschaftDBService.DeleteTeilnehmerAsync(MeisterschaftID, TeilnehmerID);
        return;
    }
}

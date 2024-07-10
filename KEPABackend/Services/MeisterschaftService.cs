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
    private IMeisterschaftDBService MeisterschaftsDBService { get; }
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator { get; }
    private MeisterschaftUpdateValidator MeisterschaftUpdateValidator { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftService(
        IMeisterschaftstypenDBService meisterschaftstypenDBService,
        IMeisterschaftDBService meisterschaftsDBService, 
        IMapper Mapper, 
        MeisterschaftCreateValidator meisterschaftCreateValidator,
        MeisterschaftUpdateValidator meisterschaftUpdateValidator
        )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
        MeisterschaftsDBService = meisterschaftsDBService;
        this.Mapper = Mapper;
        MeisterschaftCreateValidator = meisterschaftCreateValidator;
        MeisterschaftUpdateValidator = meisterschaftUpdateValidator;
    }

    /// <summary>
    /// Meisterschaft anlegen
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>ID der neuen Meisterschaft</returns>
    public async Task<long> CreateMeisterschaftAsync(MeisterschaftCreate meisterschaftCreate)
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
        long lngID = await MeisterschaftsDBService.CreateMeisterschaftAsync(meisterschaft);
        return lngID;
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

        TblMeisterschaften? meisterschaft = await MeisterschaftsDBService.GetMeisterschaftByIDAsync(meisterschaftUpdate.ID) ?? throw new MeisterschaftNotFoundException();

        List<Meisterschaftstypen> lstMT = await MeisterschaftstypenDBService.GetAllMeisterschaftstypenAsync();
        Meisterschaftstypen? find = lstMT.Find(f => f.ID == meisterschaftUpdate.MeisterschaftstypID);
        if (find == null)
        {
            throw new MeisterschaftstypNotFoundException();
        }

        Mapper.Map(meisterschaftUpdate, meisterschaft);
        await MeisterschaftsDBService.UpdateMeisterschaftAsync();

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
    public async Task<List<Meisterschaft>> GetAllMeisterschaften()
    {
        return await MeisterschaftsDBService.GetAllMeisterschaften();
    }

    /// <summary>
    /// Rückgabe einer bestimmten Meisterschaft
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task<Meisterschaft> GetMeisterschaftByID(int ID)
    {
        TblMeisterschaften? meisterschaft = await MeisterschaftsDBService.GetMeisterschaftByIDAsync(ID) ?? throw new MeisterschaftNotFoundException();
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
}

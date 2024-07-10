using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Validations;

namespace KEPABackend.Services;

/// <summary>
/// Service für MEisterschaften
/// </summary>
public class MeisterschaftService
{
    private IMeisterschaftDBService MeisterschaftsDBService { get; }
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator { get; }
    private IMeisterschaftstypenDBService MeisterschaftstypenDBService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftService(
        IMeisterschaftstypenDBService meisterschaftstypenDBService,
        IMeisterschaftDBService meisterschaftsDBService, 
        IMapper Mapper, 
        MeisterschaftCreateValidator meisterschaftCreateValidator
        )
    {
        MeisterschaftstypenDBService = meisterschaftstypenDBService;
        MeisterschaftsDBService = meisterschaftsDBService;
        this.Mapper = Mapper;
        MeisterschaftCreateValidator = meisterschaftCreateValidator;
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

}

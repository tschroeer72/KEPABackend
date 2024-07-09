using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs.Post;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Validations;

namespace KEPABackend.Services;

/// <summary>
/// Service für MEisterschaften
/// </summary>
public class MeisterschaftService
{
    private IMeisterschaftsDBService MeisterschaftsDBService { get; }
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftService(IMeisterschaftsDBService meisterschaftsDBService, IMapper Mapper, MeisterschaftCreateValidator meisterschaftCreateValidator)
    {
        MeisterschaftsDBService = meisterschaftsDBService;
        this.Mapper = Mapper;
        MeisterschaftCreateValidator = meisterschaftCreateValidator;
    }

    /// <summary>
    /// Meisterschaft anlegen
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>ID der neuen MEisterschaft</returns>
    public async Task<long> CreateMeisterschaft(MeisterschaftCreate meisterschaftCreate)
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

        var meisterschaft = Mapper.Map<TblMeisterschaften>(meisterschaftCreate);
        long lngID = await MeisterschaftsDBService.CreateMeisterschaftAsync(meisterschaft);
        return lngID;
    }

}

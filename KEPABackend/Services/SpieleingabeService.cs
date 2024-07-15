using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using KEPABackend.Validations;

namespace KEPABackend.Services;

/// <summary>
/// Spieleingabeservice
/// </summary>
public class SpieleingabeService : ISpieleingabeService
{
    private readonly ISpieleingabeDBService SpieleingabeDBService;
    private readonly IMeisterschaftDBService MeisterschaftDBService;

    private readonly IMapper Mapper;
    private readonly SpieltagCreateValidator SpieltagCreateValidator;

    /// <summary>
    /// Contructor
    /// </summary>
    public SpieleingabeService(
        ISpieleingabeDBService spieleingabeDBService, 
        IMapper mapper, 
        IMeisterschaftDBService meisterschaftDBService,
        SpieltagCreateValidator spieltagCreateValidator)
    {
        this.SpieleingabeDBService = spieleingabeDBService;
        this.Mapper = mapper;
        this.MeisterschaftDBService = meisterschaftDBService;
        this.SpieltagCreateValidator = spieltagCreateValidator;
    }


    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltagCreate"></param>
    /// <returns>ID des neuen Spieltages</returns>
    public async Task<EntityID> CreateSpieltagAsync(SpieltagCreate spieltagCreate)
    {
        try
        {
            await SpieltagCreateValidator.ValidateAndThrowAsync(spieltagCreate);
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            throw;
        }

        TblMeisterschaften? meisterschaft = await MeisterschaftDBService.GetMeisterschaftByIDAsync(spieltagCreate.MeisterschaftsID) ?? throw new MeisterschaftNotFoundException();

        DateTime dtSpieltag = Convert.ToDateTime(spieltagCreate.Spieltag.ToShortDateString());
        spieltagCreate.Spieltag = dtSpieltag;
        int? spieltagID = await SpieleingabeDBService.CheckSpieltagExistingAsync(spieltagCreate.MeisterschaftsID, dtSpieltag);

        if (spieltagID != null) 
        {
            throw new SpieltagAlreadyExistsException();
        }

        var spieltag = Mapper.Map<TblSpieltag>(spieltagCreate);
        int intSpieltagID = await SpieleingabeDBService.CreateSpieltagAsync(spieltag);
        EntityID entityID = new() { ID = intSpieltagID };
        return entityID;
        
    }
}

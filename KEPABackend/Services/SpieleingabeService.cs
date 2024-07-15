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
    private readonly IMitgliederDBService mitgliederDBService;

    /// <summary>
    /// Contructor
    /// </summary>
    public SpieleingabeService(
        ISpieleingabeDBService spieleingabeDBService, 
        IMapper mapper, 
        IMeisterschaftDBService meisterschaftDBService,
        SpieltagCreateValidator spieltagCreateValidator,
        IMitgliederDBService mitgliederDBService)
    {
        this.SpieleingabeDBService = spieleingabeDBService;
        this.Mapper = mapper;
        this.MeisterschaftDBService = meisterschaftDBService;
        this.SpieltagCreateValidator = spieltagCreateValidator;
        this.mitgliederDBService = mitgliederDBService;
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
        catch (ValidationException)
        {
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

    /// <summary>
    /// Spieltag abschließen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task CloseSpieltagAsync(int SpieltagID)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(SpieltagID) ?? throw new SpieltagNotFoundException();
        await SpieleingabeDBService.CloseSpieltagAsync(SpieltagID);
    }

    /// <summary>
    /// Spieltag löschen
    /// (keine weitere Eingabe möglich)
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteSpieltagAsync(int SpieltagID)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(SpieltagID) ?? throw new SpieltagNotFoundException();
        await SpieleingabeDBService.DeleteSpieltagAsync(SpieltagID);
    }

    /// <summary>
    /// Hole den Spieltag der in Bearbeitung ist
    /// </summary>
    /// <returns>ID und Datum des Spieltag</returns>
    public async Task<AktuellerSpieltag> GetSpieltagInBearbeitung()
    {
        return await SpieleingabeDBService.GetSpieltagInBearbeitung();
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er und Ratten
    /// </summary>
    /// <param name="SpieltagID"></param>
    /// <param name="SpielerID"></param>
    /// <returns></returns>
    public async Task<NeunerRatten> Create9erRattenAsync(int SpieltagID, int SpielerID)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied = await mitgliederDBService.GetMitgliedByIDAsync(SpielerID) ?? throw new MitgliedNotFoundException();
        int? neunerRattenID = await SpieleingabeDBService.Check9erRattenExistingAsync(SpieltagID, SpielerID);        
        if(neunerRattenID != null) throw new NeunerRattenAlreadyExistsException();

        var result = await SpieleingabeDBService.Create9erRattenAsync(SpieltagID, SpielerID);

        return result;
    }
}

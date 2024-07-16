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
    private readonly NeunerRattenUpdateValidator neunerRattenUpdateValidator;

    /// <summary>
    /// Contructor
    /// </summary>
    public SpieleingabeService(
        ISpieleingabeDBService spieleingabeDBService, 
        IMapper mapper, 
        IMeisterschaftDBService meisterschaftDBService,
        SpieltagCreateValidator spieltagCreateValidator,
        IMitgliederDBService mitgliederDBService,
        NeunerRattenUpdateValidator neunerRattenUpdateValidator)
    {
        this.SpieleingabeDBService = spieleingabeDBService;
        this.Mapper = mapper;
        this.MeisterschaftDBService = meisterschaftDBService;
        this.SpieltagCreateValidator = spieltagCreateValidator;
        this.mitgliederDBService = mitgliederDBService;
        this.neunerRattenUpdateValidator = neunerRattenUpdateValidator;
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
    public async Task<AktuellerSpieltag?> GetSpieltagInBearbeitung()
    {
        return await SpieleingabeDBService.GetSpieltagInBearbeitung();
    }

    /// <summary>
    /// Erzeuge Tabelleneintrag für 9er und Ratten
    /// </summary>
    /// <param name="neunerRattenCreate"></param>
    /// <returns></returns>
    public async Task<EntityID> Create9erRattenAsync(NeunerRattenCreate neunerRattenCreate)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(neunerRattenCreate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied = await mitgliederDBService.GetMitgliedByIDAsync(neunerRattenCreate.SpielerID) ?? throw new MitgliedNotFoundException();
        int? neunerRattenID = await SpieleingabeDBService.Check9erRattenExistingAsync(neunerRattenCreate.SpieltagID, neunerRattenCreate.SpielerID);        
        if(neunerRattenID != null) throw new NeunerRattenAlreadyExistsException();

        var neunerRatten = Mapper.Map<Tbl9erRatten>(neunerRattenCreate);
        var result = await SpieleingabeDBService.Create9erRattenAsync(neunerRatten);

        EntityID entityID = new() { ID = result };
        return entityID;
    }

    /// <summary>
    /// Aktualisiere NeunerRatten Eintität
    /// </summary>
    /// <param name="neunerRattenUpdate"></param>
    /// <returns></returns>
    public async Task<NeunerRatten> Update9erRattenAsync(NeunerRattenUpdate neunerRattenUpdate)
    {
        try
        {
            await neunerRattenUpdateValidator.ValidateAndThrowAsync(neunerRattenUpdate);
        }
        catch (ValidationException)
        {
            throw;
        }

        Tbl9erRatten? neunerRatten = await SpieleingabeDBService.Get9erRattenByID(neunerRattenUpdate.ID) ?? throw new NeunerRattenNotFoundException();
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(neunerRattenUpdate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied = await mitgliederDBService.GetMitgliedByIDAsync(neunerRattenUpdate.SpielerID) ?? throw new MitgliedNotFoundException();
        Mapper.Map(neunerRattenUpdate, neunerRatten);
        await SpieleingabeDBService.Update9erRattenAsync();

        var updatedNeunerRatten = new NeunerRatten()
        {
            ID = neunerRatten.Id,
            SpieltagID = neunerRatten.SpieltagId,
            SpielerID = neunerRatten.SpielerId,
            Neuner = neunerRatten.Neuner,
            Ratten = neunerRatten.Ratten
        };

        return updatedNeunerRatten;
    }
}

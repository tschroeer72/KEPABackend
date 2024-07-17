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
    private readonly Spiel6TageRennenUpdateValidator spiel6TageRennenUpdateValidator;
    private readonly SpielBlitztunierUpdateValidator spielBlitztunierUpdateValidator;
    private readonly SpielMeisterschaftUpdateValidator spielMeisterschaftUpdateValidator;

    /// <summary>
    /// Contructor
    /// </summary>
    public SpieleingabeService(
        ISpieleingabeDBService spieleingabeDBService, 
        IMapper mapper, 
        IMeisterschaftDBService meisterschaftDBService,
        SpieltagCreateValidator spieltagCreateValidator,
        IMitgliederDBService mitgliederDBService,
        NeunerRattenUpdateValidator neunerRattenUpdateValidator,
        Spiel6TageRennenUpdateValidator spiel6TageRennenUpdateValidator,
        SpielBlitztunierUpdateValidator spielBlitztunierUpdateValidator,
        SpielMeisterschaftUpdateValidator spielMeisterschaftUpdateValidator)
    {
        this.SpieleingabeDBService = spieleingabeDBService;
        this.Mapper = mapper;
        this.MeisterschaftDBService = meisterschaftDBService;
        this.SpieltagCreateValidator = spieltagCreateValidator;
        this.mitgliederDBService = mitgliederDBService;
        this.neunerRattenUpdateValidator = neunerRattenUpdateValidator;
        this.spiel6TageRennenUpdateValidator = spiel6TageRennenUpdateValidator;
        this.spielBlitztunierUpdateValidator = spielBlitztunierUpdateValidator;
        this.spielMeisterschaftUpdateValidator = spielMeisterschaftUpdateValidator;
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
    public async Task<AktuellerSpieltag?> GetSpieltagInBearbeitungAsync()
    {
        return await SpieleingabeDBService.GetSpieltagInBearbeitungAsync();
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
        int intID = await SpieleingabeDBService.Create9erRattenAsync(neunerRatten);

        EntityID entityID = new() { ID = intID };
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

    /// <summary>
    /// Neuner/Ratten löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteNeunerRattenAsync(int SpieltagID)
    {
        Tbl9erRatten? neuerRatten = await SpieleingabeDBService.Get9erRattenByID(SpieltagID) ?? throw new NeunerRattenNotFoundException();
        await SpieleingabeDBService.DeleteNeunerRattenAsync(SpieltagID);
    }

    /// <summary>
    /// Erzeuge Mannschaft für das 6-Tage-Rennen
    /// </summary>
    /// <param name="spiel6TageRennenCreate"></param>
    /// <returns></returns>
    public async Task<EntityID> CreateSpiel6TageRennenAsync(Spiel6TageRennenCreate spiel6TageRennenCreate)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spiel6TageRennenCreate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spiel6TageRennenCreate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spiel6TageRennenCreate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");
        int? spiel6TageRennenCheck = await SpieleingabeDBService.CheckSpiel6TageRennenExistingAsync(spiel6TageRennenCreate.SpieltagID, spiel6TageRennenCreate.SpielerID1, spiel6TageRennenCreate.SpielerID2);
        if (spiel6TageRennenCheck != null) throw new Spiel6TageRennenAlreadyExistsException();

        var spiel6TageRennen = Mapper.Map<TblSpiel6TageRennen>(spiel6TageRennenCreate);
        int intID = await SpieleingabeDBService.CreateSpiel6TageRennenAsync(spiel6TageRennen);

        EntityID entityID = new() { ID = intID };
        return entityID;
    }

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spiel6TageRennenUpdate"></param>
    /// <returns></returns>
    public async Task<Spiel6TageRennen> UpdateSpiel6TageRennenAsync(Spiel6TageRennenUpdate spiel6TageRennenUpdate)
    {
        try
        {
            await spiel6TageRennenUpdateValidator.ValidateAndThrowAsync(spiel6TageRennenUpdate);
        }
        catch (ValidationException)
        {
            throw;
        }

        TblSpiel6TageRennen? spiel6TageRennen = await SpieleingabeDBService.GetSpiel6TageRennenByID(spiel6TageRennenUpdate.ID) ?? throw new Spiel6TageRennenNotFoundException();
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spiel6TageRennenUpdate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spiel6TageRennenUpdate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spiel6TageRennenUpdate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");

        Mapper.Map(spiel6TageRennenUpdate, spiel6TageRennen);
        await SpieleingabeDBService.UpdateSpiel6TageRennenAsync();

        var updatedSpiel6TageRennen = new Spiel6TageRennen()
        {
            ID = spiel6TageRennen.Id,
            SpieltagID = spiel6TageRennen.SpieltagId,
            SpielerID1 = spiel6TageRennen.SpielerId1,
            SpielerID2 = spiel6TageRennen.SpielerId2,
            Runden = spiel6TageRennen.Runden,
            Punkte = spiel6TageRennen.Punkte
        };

        return updatedSpiel6TageRennen;
    }

    /// <summary>
    /// Mannschaft auf 6-Tage-Rennen löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteSpiel6TageRennenAsync(int SpieltagID)
    {
        TblSpiel6TageRennen? spiel6TageRennen = await SpieleingabeDBService.GetSpiel6TageRennenByID(SpieltagID) ?? throw new Spiel6TageRennenNotFoundException();
        await SpieleingabeDBService.DeleteSpiel6TageRennenAsync(SpieltagID);
    }

    /// <summary>
    /// Erzeuge Eintrag für Blitztunier
    /// </summary>
    /// <param name="spielBlitztunierCreate"></param>
    /// <returns></returns>
    public async Task<EntityID> CreateSpielBlitztunierAsync(SpielBlitztunierCreate spielBlitztunierCreate)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spielBlitztunierCreate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spielBlitztunierCreate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spielBlitztunierCreate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");
        int? spielBlitztunierCheck = await SpieleingabeDBService.CheckSpielBlitztunierExistingAsync(spielBlitztunierCreate.SpieltagID, spielBlitztunierCreate.SpielerID1, spielBlitztunierCreate.SpielerID2);
        if (spielBlitztunierCheck != null) throw new SpielBlitztunierAlreadyExistsException();

        var spielBlitztunier = Mapper.Map<TblSpielBlitztunier>(spielBlitztunierCreate);
        int intID = await SpieleingabeDBService.CreateSpielBlitztunierAsync(spielBlitztunier);

        EntityID entityID = new() { ID = intID };
        return entityID;
    }

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spielBlitztunierUpdate"></param>
    /// <returns></returns>
    public async Task<SpielBlitztunier> UpdateSpielBlitztunierAsync(SpielBlitztunierUpdate spielBlitztunierUpdate)
    {
        try
        {
            await spielBlitztunierUpdateValidator.ValidateAndThrowAsync(spielBlitztunierUpdate);
        }
        catch (ValidationException)
        {
            throw;
        }

        TblSpielBlitztunier? spielBlitztunier = await SpieleingabeDBService.GetSpielBlitztunierByID(spielBlitztunierUpdate.ID) ?? throw new SpielBlitztunierNotFoundException();
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spielBlitztunierUpdate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spielBlitztunierUpdate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spielBlitztunierUpdate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");

        Mapper.Map(spielBlitztunierUpdate, spielBlitztunier);
        await SpieleingabeDBService.UpdateSpielBlitztunierAsync();

        var updatedSpielBlitztunier = new SpielBlitztunier()
        {
            ID = spielBlitztunier.Id,
            SpieltagID = spielBlitztunier.SpieltagId,
            SpielerID1 = spielBlitztunier.SpielerId1,
            SpielerID2 = spielBlitztunier.SpielerId2,
            PunkteSpieler1 = spielBlitztunier.PunkteSpieler1,
            PunkteSpieler2 = spielBlitztunier.PunkteSpieler2
        };

        return updatedSpielBlitztunier;
    }

    /// <summary>
    /// Paarung aus Blitztunier löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteSpielBlitztunierAsync(int SpieltagID)
    {
        TblSpielBlitztunier? spielBlitztunier = await SpieleingabeDBService.GetSpielBlitztunierByID(SpieltagID) ?? throw new SpielBlitztunierNotFoundException();
        await SpieleingabeDBService.DeleteSpielBlitztunierAsync(SpieltagID);
    }

    /// <summary>
    /// Erzeuge Eintrag für Meisterschaft
    /// </summary>
    /// <param name="spielMeisterschaftCreate"></param>
    /// <returns></returns>
    public async Task<EntityID> CreateSpielMeisterschaftAsync(SpielMeisterschaftCreate spielMeisterschaftCreate)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spielMeisterschaftCreate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spielMeisterschaftCreate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spielMeisterschaftCreate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");
        int? spielMeisterschaftCheck = await SpieleingabeDBService.CheckSpielMeisterschaftExistingAsync(spielMeisterschaftCreate.SpieltagID, spielMeisterschaftCreate.SpielerID1, spielMeisterschaftCreate.SpielerID2);
        if (spielMeisterschaftCheck != null) throw new SpielMeisterschaftAlreadyExistsException();

        var spielMeisterschaft = Mapper.Map<TblSpielMeisterschaft>(spielMeisterschaftCreate);
        int intID = await SpieleingabeDBService.CreateSpielMeisterschaftAsync(spielMeisterschaft);

        EntityID entityID = new() { ID = intID };
        return entityID;
    }

    /// <summary>
    /// Ergebnisse eintragen
    /// </summary>
    /// <param name="spielMeisterschaftUpdate"></param>
    /// <returns></returns>
    public async Task<SpielMeisterschaft> UpdateSpielMeisterschaftAsync(SpielMeisterschaftUpdate spielMeisterschaftUpdate)
    {
        try
        {
            await spielMeisterschaftUpdateValidator.ValidateAndThrowAsync(spielMeisterschaftUpdate);
        }
        catch (ValidationException)
        {
            throw;
        }

        TblSpielMeisterschaft? spielMeisterschaft = await SpieleingabeDBService.GetSpielMeisterschaftByID(spielMeisterschaftUpdate.ID) ?? throw new SpielMeisterschaftNotFoundException();
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spielMeisterschaftUpdate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spielMeisterschaftUpdate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spielMeisterschaftUpdate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");

        Mapper.Map(spielMeisterschaftUpdate, spielMeisterschaft);
        await SpieleingabeDBService.UpdateSpielMeisterschaftAsync();

        var updatedSpielMeisterschaft = new SpielMeisterschaft()
        {
            ID = spielMeisterschaft.Id,
            SpieltagID = spielMeisterschaft.SpieltagId,
            SpielerID1 = spielMeisterschaft.SpielerId1,
            SpielerID2 = spielMeisterschaft.SpielerId2,
            HolzSpieler1 = spielMeisterschaft.HolzSpieler1,
            HolzSpieler2 = spielMeisterschaft.HolzSpieler2
        };

        return updatedSpielMeisterschaft;
    }

    /// <summary>
    /// Paarung aus Meisterschaft löschen
    /// </summary>
    /// <param name="SpieltagID"></param>
    public async Task DeleteSpielMeisterschaftAsync(int SpieltagID)
    {
        TblSpielMeisterschaft? spielMeisterschaft = await SpieleingabeDBService.GetSpielMeisterschaftByID(SpieltagID) ?? throw new SpielMeisterschaftNotFoundException();
        await SpieleingabeDBService.DeleteSpielMeisterschaftAsync(SpieltagID);
    }

    /// <summary>
    /// Erzeuge Eintrag für Kombimeisterschaft
    /// </summary>
    /// <param name="spielKombimeisterschaftCreate"></param>
    /// <returns></returns>
    public async Task<EntityID> CreateSpielKombimeisterschaftAsync(SpielKombimeisterschaftCreate spielKombimeisterschaftCreate)
    {
        TblSpieltag? spieltag = await SpieleingabeDBService.GetSpieltagByIDAsync(spielKombimeisterschaftCreate.SpieltagID) ?? throw new SpieltagNotFoundException();
        TblMitglieder? mitglied1 = await mitgliederDBService.GetMitgliedByIDAsync(spielKombimeisterschaftCreate.SpielerID1) ?? throw new MitgliedNotFoundException("Spieler 1 nicht gefunden");
        TblMitglieder? mitglied2 = await mitgliederDBService.GetMitgliedByIDAsync(spielKombimeisterschaftCreate.SpielerID2) ?? throw new MitgliedNotFoundException("Spieler 2 nicht gefunden");
        int? spielKombimeisterschaftCheck = await SpieleingabeDBService.CheckSpielKombimeisterschaftExistingAsync(spielKombimeisterschaftCreate.SpieltagID, spielKombimeisterschaftCreate.SpielerID1, spielKombimeisterschaftCreate.SpielerID2, spielKombimeisterschaftCreate.HinRückrunde);
        if (spielKombimeisterschaftCheck != null) throw new SpielKombimeisterschaftAlreadyExistsException();

        var spielKombimeisterschaft = Mapper.Map<TblSpielKombimeisterschaft>(spielKombimeisterschaftCreate);
        int intID = await SpieleingabeDBService.CreateSpielKombimeisterschaftAsync(spielKombimeisterschaft);

        EntityID entityID = new() { ID = intID };
        return entityID;
    }
}

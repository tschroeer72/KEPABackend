using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;

namespace KEPABackend.Services;

/// <summary>
/// Service SPielergebnisse
/// </summary>
public class SpielergebnisseService : ISpielergebnisseService
{
    private readonly ISpielergebnisseDBService spielergebnisseDBService;

    /// <summary>
    /// Contructor
    /// </summary>
    /// <param name="spielergebnisseDBService"></param>
    public SpielergebnisseService(ISpielergebnisseDBService spielergebnisseDBService)
    {
        this.spielergebnisseDBService = spielergebnisseDBService;
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu 6-Tage-Rennen
    /// </summary>
    /// <returns>Liste aller 6-Tage-Rennen</returns>
    public async Task<List<vwSpiel6TageRennen>> GetErgebnisse6TageRennenAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisse6TageRennenAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Blitztunier
    /// </summary>
    /// <returns>Liste aller Blitztunier</returns>
    public async Task<List<vwSpielBlitztunier>> GetErgebnisseBlitztunierAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisseBlitztunierAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Kombimeisterschaft
    /// </summary>
    /// <returns>Liste aller Kombimeisterschaft</returns>
    public async Task<List<vwSpielKombimeisterschaft>> GetErgebnisseKombimeisterschaftAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisseKombimeisterschaftAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Meisterschaft
    /// </summary>
    /// <returns>Liste aller Meisterschaft</returns>
    public async Task<List<vwSpielMeisterschaft>> GetErgebnisseMeisterschaftAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisseMeisterschaftAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    public async Task<List<vwNeunerRatten>> GetErgebnisseNeunerRattenAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisseNeunerRattenAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Pokalspielen
    /// </summary>
    /// <returns>Liste aller Pokalspiele</returns>
    public async Task<List<vwSpielPokal>> GetErgebnissePokalAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnissePokalAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Sargkegeln
    /// </summary>
    /// <returns>Liste aller Sargkegeln</returns>
    public async Task<List<vwSpielSargkegeln>> GetErgebnisseSargkegelnAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetErgebnisseSargkegelnAsync(SpieltagID);
    }
}

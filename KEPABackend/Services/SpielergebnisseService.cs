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
    public async Task<List<vwSpiel6TageRennen>> GetAllErgebnisse6TageRennenAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetAllErgebnisse6TageRennenAsync(SpieltagID);
    }

    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    public async Task<List<vwNeunerRatten>> GetAllErgebnisseNeunerRattenAsync(int SpieltagID = -1)
    {
        return await spielergebnisseDBService.GetAllErgebnisseNeunerRattenAsync(SpieltagID);
    }
}

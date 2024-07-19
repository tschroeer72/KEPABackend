using KEPABackend.DTOs.Output;

namespace KEPABackend.Interfaces.DBServices;

public interface ISpielergebnisseDBService
{
    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    Task<List<vwNeunerRatten>> GetErgebnisseNeunerRattenAsync(int SpieltagID = -1);

    /// <summary>
    /// Liefere alle Ergebnisse zu 6-Tage-Rennen
    /// </summary>
    /// <returns>Liste aller 6-Tage-Rennen</returns>
    Task<List<vwSpiel6TageRennen>> GetErgebnisse6TageRennenAsync(int SpieltagID = -1);
}

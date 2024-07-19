using KEPABackend.DTOs.Output;

namespace KEPABackend.Interfaces.DBServices;

public interface ISpielergebnisseDBService
{
    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    Task<List<vwNeunerRatten>> GetAllErgebnisseNeunerRattenAsync(int SpieltagID = -1);
}

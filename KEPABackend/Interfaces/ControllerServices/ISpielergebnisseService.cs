using KEPABackend.DTOs.Output;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface
/// </summary>
public interface ISpielergebnisseService
{
    /// <summary>
    /// Liefere alle Ergebnisse zu Neuner/Ratten
    /// </summary>
    /// <returns>Liste aller Neuner/Ratten</returns>
    Task<List<vwNeunerRatten>> GetAllErgebnisseNeunerRattenAsync(int SpieltagID = -1);
}

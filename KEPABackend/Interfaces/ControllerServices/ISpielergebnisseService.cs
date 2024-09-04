using KEPABackend.DTOs.Output;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface für SpielergebnisseService
/// </summary>
public interface ISpielergebnisseService
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

    /// <summary>
    /// Liefere alle Ergebnisse zu Pokalspielen
    /// </summary>
    /// <returns>Liste aller Pokalspiele</returns>
    Task<List<vwSpielPokal>> GetErgebnissePokalAsync(int SpieltagID = -1);

    /// <summary>
    /// Liefere alle Ergebnisse zu Sargkegeln
    /// </summary>
    /// <returns>Liste aller Sargkegeln</returns>
    Task<List<vwSpielSargkegeln>> GetErgebnisseSargkegelnAsync(int SpieltagID = -1);

    /// <summary>
    /// Liefere alle Ergebnisse zu Blitztunier
    /// </summary>
    /// <returns>Liste aller Blitztunier</returns>
    Task<List<vwSpielBlitztunier>> GetErgebnisseBlitztunierAsync(int SpieltagID = -1);

    /// <summary>
    /// Liefere alle Ergebnisse zu Meisterschaft
    /// </summary>
    /// <returns>Liste aller Meisterschaft</returns>
    Task<List<vwSpielMeisterschaft>> GetErgebnisseMeisterschaftAsync(int SpieltagID = -1);

    /// <summary>
    /// Liefere alle Ergebnisse zu Kombimeisterschaft
    /// </summary>
    /// <returns>Liste aller Kombimeisterschaft</returns>
    Task<List<vwSpielKombimeisterschaft>> GetErgebnisseKombimeisterschaftAsync(int SpieltagID = -1);
}

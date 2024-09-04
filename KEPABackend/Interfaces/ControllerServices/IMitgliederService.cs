using KEPABackend.DTOs.Output;
using KEPABackend.DTOs.Input;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface für MitgliederService
/// </summary>
public interface IMitgliederService
{
    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitgliedCreate"></param>
    /// <returns>ID der neuen Entität</returns>
    Task<EntityID> CreateMitgliederAsync(MitgliedCreate mitgliedCreate);

    /// <summary>
    /// Service UpdateMitglied
    /// </summary>
    /// <param name="mitgliedUpdate"></param>
    /// <returns>Geänderte Entity</returns>
    Task<Mitgliederliste> UpdateMitgliederAsync(MitgliedUpdate mitgliedUpdate);

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <param name="bAktiv"> true (Default) = nur aktive Mitglieder; false = alle Mitglieder</param>
    /// <returns>Liste aller Mitglieder</returns>
    Task<List<Mitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true);

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    Task<Mitgliederliste> GetMitgliedByIDAsync(int ID);

    /// <summary>
    /// Überprüfung, ob die Credentails korrekt sind
    /// </summary>
    /// <param name="sUsername"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword);
}

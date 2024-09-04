using KEPABackend.DTOs.Output;
using KEPABackend.Models;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface für MitgliederDBService
/// </summary>
public interface IMitgliederDBService
{
    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitglied"></param>
    /// <returns>ID der neuen Entität</returns>
    Task<int> CreateMitgliederAsync(TblMitglieder mitglied);

    /// <summary>
    /// Speichert die Änderungen in der DB
    /// </summary>
    /// <returns>void</returns>
    Task UpdateMitgliederAsync();

    /// <summary>
    /// Service GetAllMitgliederAsync
    /// </summary>
    /// <param name="bAktiv">true (Default) = nur aktive Mitglieder; false = alle Mitglieder</param>
    /// <returns>Liste aller Mitglieder</returns>
    /// 
    Task<List<Mitgliederliste>> GetAllMitgliederAsync(bool bAktiv = true);

    /// <summary>
    /// Service GetMitgliedByIDAsync
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Mitglied mit der ID </returns>
    Task<TblMitglieder?> GetMitgliedByIDAsync(int ID);

    /// <summary>
    /// Überprüfung, ob die Credentails korrekt sind
    /// </summary>
    /// <param name="sUsername"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword);
}

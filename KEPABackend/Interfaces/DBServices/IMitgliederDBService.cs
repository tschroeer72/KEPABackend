﻿using KEPABackend.DTOs.Get;
using KEPABackend.Modell;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface 
/// </summary>
public interface IMitgliederDBService
{
    /// <summary>
    /// Service CreateMitgliederAsync
    /// </summary>
    /// <param name="mitglied"></param>
    /// <returns>ID der neuen Entität</returns>
    Task<long> CreateMitgliederAsync(TblMitglieder mitglied);

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
}

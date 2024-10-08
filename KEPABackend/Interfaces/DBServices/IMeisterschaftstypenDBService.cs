﻿using KEPABackend.DTOs.Output;
using KEPABackend.Models;

namespace KEPABackend.Interfaces.DBServices;

/// <summary>
/// Interface für MeisterschaftstypenDBService
/// </summary>
public interface IMeisterschaftstypenDBService
{
    /// <summary>
    /// Service GetAllMeisterschaftstypenAsync
    /// </summary>
    /// <returns>Liste aller Meisterschaftstypen</returns>
    Task<List<Meisterschaftstypen>> GetAllMeisterschaftstypenAsync();

    /// <summary>
    /// Suche Meisterschaftstyp mit der ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns>Meisterschaftstyp oder null</returns>
    Task<Meisterschaftstypen?> GetMeisterschaftstypByIDAsync(int ID);
}

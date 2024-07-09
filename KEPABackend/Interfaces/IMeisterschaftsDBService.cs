﻿using KEPABackend.Modell;

namespace KEPABackend.Interfaces;

/// <summary>
/// Interface IMeisterschaftsDBService
/// </summary>
public interface IMeisterschaftsDBService
{
    /// <summary>
    /// Service CreateMeisterschaftAsync
    /// </summary>
    /// <param name="meisterschaft"></param>
    /// <returns>ID der neuen Entität</returns>
    Task<long> CreateMeisterschaftAsync(TblMeisterschaften meisterschaft);
}

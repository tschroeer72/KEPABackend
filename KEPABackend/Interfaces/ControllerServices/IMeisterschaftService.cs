using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using Microsoft.AspNetCore.Mvc;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface 
/// </summary>
public interface IMeisterschaftService
{
    /// <summary>
    /// Meisterschaft anlegen
    /// </summary>
    /// <param name="meisterschaftCreate"></param>
    /// <returns>ID der neuen Meisterschaft</returns>
    Task<long> CreateMeisterschaftAsync(MeisterschaftCreate meisterschaftCreate);

    /// <summary>
    /// Service Update Meisterschaft
    /// </summary>
    /// <param name="meisterschaftUpdate"></param>
    /// <returns>Geänderte Entity</returns>
    Task<Meisterschaft> UpdateMeisterschaftAsync(MeisterschaftUpdate meisterschaftUpdate);

    /// <summary>
    /// Liste aller Meisterschaften
    /// </summary>
    /// <returns>Liste aller Meisterschaften</returns>
    Task<List<Meisterschaft>> GetAllMeisterschaften();

    /// <summary>
    /// Rückgabe einer bestimmten Meisterschaft
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    Task<Meisterschaft> GetMeisterschaftByID(int ID);
}

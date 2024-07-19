using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
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
    Task<EntityID> CreateMeisterschaftAsync(MeisterschaftCreate meisterschaftCreate);

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
    Task<List<Meisterschaft>> GetAllMeisterschaftenAsync();

    /// <summary>
    /// Rückgabe einer bestimmten Meisterschaft
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    Task<Meisterschaft> GetMeisterschaftByIDAsync(int ID);

    /// <summary>
    /// Teilnehmer zu einer Meisterschaft hinzufügen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    Task AddTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID);

    /// <summary>
    /// Teilnehmer aus einer Meisterschaft löschen
    /// </summary>
    /// <param name="MeisterschaftID"></param>
    /// <param name="TeilnehmerID"></param>
    Task DeleteTeilnehmerAsync(int MeisterschaftID, int TeilnehmerID);
}

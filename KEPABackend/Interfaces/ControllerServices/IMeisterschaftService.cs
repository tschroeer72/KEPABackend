using KEPABackend.DTOs.Post;

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
}

using KEPABackend.DTOs.Post;

namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface 
/// </summary>
public interface ISpieleingabeService
{
    /// <summary>
    /// Erstelle einen Spieltag
    /// </summary>
    /// <param name="spieltagCreate"></param>
    /// <returns>ID des neuen SPieltages</returns>
    Task<EntityID> CreateSpieltagAsync(SpieltagCreate spieltagCreate);
}

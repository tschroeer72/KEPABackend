using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post EntityID
/// </summary>
public record EntityID
{
    /// <summary>
    /// ID der gerade angelegten Entität
    /// </summary>
    public int ID { get; set; } = default!;
}

using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post SpielSargkegelnCreate Create
/// </summary>
public record SpielSargkegelnCreate
{
    /// <summary>
    /// SpieltagID
    /// </summary>
    [Required] 
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID
    /// </summary>
    [Required] 
    public int SpielerID { get; set; }
}
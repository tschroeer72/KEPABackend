using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post SpielSargkegelnUpdate 
/// </summary>
public record SpielSargkegelnUpdate
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    [Required]
    public int ID { get; set; } = default!;

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

    /// <summary>
    /// Platzierung
    /// </summary>
    [Required]
    public int Platzierung { get; set; }
}
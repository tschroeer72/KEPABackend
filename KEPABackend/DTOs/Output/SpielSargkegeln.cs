using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get Spiel SpielSargkegeln (Änderungen)
/// </summary>
public record SpielSargkegeln
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    [Required]
    public int ID { get; set; } = default!;

    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID
    /// </summary>
    public int SpielerID { get; set; }

    /// <summary>
    /// Platzierung
    /// </summary>
    public int Platzierung { get; set; }
}

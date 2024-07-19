using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get SpielMeisterschaft 
/// </summary>
public record SpielMeisterschaft
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
    /// SpielerID1
    /// </summary>
    [Required]
    public int SpielerID1 { get; set; }

    /// <summary>
    /// SpielerID2
    /// </summary>
    [Required]
    public int SpielerID2 { get; set; }

    /// <summary>
    /// Holz Spieler 1
    /// </summary>
    [Required]
    public int HolzSpieler1 { get; set; }

    /// <summary>
    /// Holz Spieler 2
    /// </summary>
    [Required]
    public int HolzSpieler2 { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Get;

/// <summary>
/// DTO Get SpielBlitztunier 
/// </summary>
public record SpielBlitztunier
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
    /// Punkte Spieler 1
    /// </summary>
    [Required]
    public int PunkteSpieler1 { get; set; }

    /// <summary>
    /// Punkte Spieler 2
    /// </summary>
    [Required]
    public int PunkteSpieler2 { get; set; }
}
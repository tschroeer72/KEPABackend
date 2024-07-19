using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get SpielKombimeisterschaft 
/// </summary>
public record SpielKombimeisterschaft
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
    /// Spieler 1 Punkte 3 bis 8
    /// </summary>
    [Required]
    public int Spieler1Punkte3bis8 { get; set; }

    /// <summary>
    /// Spieler 1 Punkte 5 Kugeln
    /// </summary>
    [Required]
    public int Spieler1Punkte5Kugeln { get; set; }

    /// <summary>
    /// Spieler 2 Punkte 3 bis 8
    /// </summary>
    [Required]
    public int Spieler2Punkte3bis8 { get; set; }

    /// <summary>
    /// Spieler 2 Punkte 5 Kugeln
    /// </summary>
    [Required]
    public int Spieler2Punkte5Kugeln { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post Spiel6TageRennenUpdate 
/// </summary>
public record Spiel6TageRennenUpdate
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
    /// Runden
    /// </summary>
    [Required] 
    public int Runden { get; set; }

    /// <summary>
    /// Punkte
    /// </summary>
    [Required] 
    public int Punkte { get; set; }
}
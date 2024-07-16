namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post Spiel6TageRennenUpdate 
/// </summary>
public record Spiel6TageRennenUpdate
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int ID { get; set; } = default!;

    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID1
    /// </summary>
    public int SpielerID1 { get; set; }

    /// <summary>
    /// SpielerID2
    /// </summary>
    public int SpielerID2 { get; set; }

    /// <summary>
    /// Runden
    /// </summary>
    public int Runden { get; set; }

    /// <summary>
    /// Punkte
    /// </summary>
    public int Punkte { get; set; }
}
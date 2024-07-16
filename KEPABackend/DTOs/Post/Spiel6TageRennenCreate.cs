namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post Spiel6TageRennenCreate Create
/// </summary>
public record Spiel6TageRennenCreate
{
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
}
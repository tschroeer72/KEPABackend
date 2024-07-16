namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post NeunerRatten Create
/// </summary>
public record NeunerRattenCreate
{
    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID
    /// </summary>
    public int SpielerID { get; set; }
}
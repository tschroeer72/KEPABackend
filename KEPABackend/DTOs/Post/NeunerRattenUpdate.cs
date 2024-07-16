using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO POST NeunerRatten
/// </summary>
public record NeunerRattenUpdate
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
    /// SpielerID
    /// </summary>
    public int SpielerID { get; set; }

    /// <summary>
    /// Geschobene Neuner
    /// </summary>
    public int Neuner { get; set; }

    /// <summary>
    /// Geschobene Ratten
    /// </summary>
    public int Ratten { get; set; }
}

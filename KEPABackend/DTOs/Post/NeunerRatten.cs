using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO PUSH NeunerRatten
/// </summary>
public record NeunerRatten
{
    /// <summary>
    /// ID der gerade angelegten Entität
    /// </summary>
    public int ID { get; set; } = default!;
    public int SpieltagID { get; set; }
    public int SpielerID { get; set; }
    public int Neuner { get; set; }
    public int Ratten { get; set; }
}

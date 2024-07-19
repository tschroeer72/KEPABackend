using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post NeunerRatten
/// </summary>
public record NeunerRattenUpdate
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
    /// SpielerID
    /// </summary>
    [Required] 
    public int SpielerID { get; set; }

    /// <summary>
    /// Geschobene Neuner
    /// </summary>
    [Required] 
    public int Neuner { get; set; }

    /// <summary>
    /// Geschobene Ratten
    /// </summary>
    [Required] 
    public int Ratten { get; set; }
}

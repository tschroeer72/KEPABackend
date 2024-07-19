using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post NeunerRatten Create
/// </summary>
public record NeunerRattenCreate
{
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
}
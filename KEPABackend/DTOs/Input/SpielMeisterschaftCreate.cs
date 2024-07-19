using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post SpielMeisterschaftCreate 
/// </summary>
public record SpielMeisterschaftCreate
{
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
}
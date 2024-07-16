using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Get;

/// <summary>
/// DTO Get AktuellerSpieltag
/// </summary>
public class AktuellerSpieltag
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Spieltag
    /// </summary>
    public DateTime? Spieltag { get; set; } = default!;
}

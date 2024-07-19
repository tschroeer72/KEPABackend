using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get Meisterschaftstypen
/// </summary>
public class Meisterschaftstypen
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Meisterschaftstyp
    /// </summary>
    public string Meisterschaftstyp { get; set; } = default!;
}

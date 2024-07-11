using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Get;

/// <summary>
/// DTO GET Meisterschaft
/// 
/// </summary>
public class Meisterschaft
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Bezeichnung
    /// </summary>
    public string Bezeichnung { get; set; } = default!;

    /// <summary>
    /// Beginn
    /// </summary>
    public DateTime Beginn { get; set; } = default!;

    /// <summary>
    /// Ende
    /// </summary>
    public DateTime? Ende { get; set; }


    /// <summary>
    /// MeisterschaftstypID
    /// </summary>
    public int MeisterschaftstypID { get; set; }

    /// <summary>
    /// TurboDB ID
    /// </summary>
    public string? TurboDbnummer { get; set; }

    /// <summary>
    /// Aktiv
    /// </summary>
    public int Aktiv { get; set; }

    /// <summary>
    /// Bemerkungen
    /// </summary>
    public string? Bemerkungen { get; set; }    
}

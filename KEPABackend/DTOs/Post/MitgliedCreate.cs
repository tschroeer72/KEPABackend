using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

//public record MitgliedCreate(
//    [Required] string Vorname,
//    [Required] string Nachname, 
//    string? Anrede,
//    [Required] DateTime MitgliedSeit,
//    DateTime? AusgeschiedenAm,
//    bool Ehemaliger,
//    string? Email,
//    string? Fax,
//    DateTime Geburtsdatum,
//    int? HolzGes,
//    int? HolzMax,
//    int? HolzMin,
//    string? Ort,
//    DateTime? PassivSeit,
//    string? Platz,
//    string? PLZ,
//    int? Punkte,
//    int? SpAnz,
//    int? SpGew,
//    int? SpUn,
//    int? SpVerl,
//    string? Spitzname,
//    string? Straße,
//    string? TelefonFirma,
//    string? TelefonMobil,
//    string? TelefonPrivat,
//    string? TurboDbnummer);

/// <summary>
/// DTO PUSH MitgliedCreate
/// </summary>
public record MitgliedCreate
{
    [Required]
    [MaxLength(50)]
    public string Vorname { get; set; } = default!;
    [Required]
    [MaxLength(50)]
    public string Nachname { get; set; } = default!;
    [MaxLength(50)]
    public string? Anrede { get; set; }
    [Required]
    public DateTime MitgliedSeit { get; set; }
    public DateTime? AusgeschiedenAm { get; set; }
    public bool Ehemaliger { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    [MaxLength(50)]
    public string? Fax { get; set; }
    public DateTime Geburtsdatum { get; set; }
    public int? HolzGes { get; set; }
    public int? HolzMax { get; set; }
    public int? HolzMin { get; set; }
    [MaxLength(50)]
    public string? Ort { get; set; }
    public DateTime? PassivSeit { get; set; }
    [MaxLength(255)]
    public string? Platz { get; set; }
    [MinLength(5)]
    [MaxLength(5)]
    public string? PLZ { get; set; }
    public int? Punkte { get; set; }
    public int? SpAnz { get; set; }
    public int? SpGew { get; set; }
    public int? SpUn { get; set; }
    public int? SpVerl { get; set; }
    [MaxLength(50)]
    public string? Spitzname { get; set; }
    [MaxLength(50)]
    public string? Straße { get; set; }
    [MaxLength(50)]
    public string? TelefonFirma { get; set; }
    [MaxLength(50)]
    public string? TelefonMobil { get; set; }
    [MaxLength(50)]
    public string? TelefonPrivat { get; set; }
    public string? TurboDbnummer { get; set; }
    public string? Bemerkungen { get; set; }
    public string? Notizen { get; set; }
}

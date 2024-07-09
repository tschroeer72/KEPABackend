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
    /// <summary>
    /// Vorname
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Vorname { get; set; } = default!;

    /// <summary>
    /// Nachname
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Nachname { get; set; } = default!;

    /// <summary>
    /// Anrede
    /// </summary>
    [MaxLength(50)]
    public string? Anrede { get; set; }

    /// <summary>
    /// Mitglied seit
    /// </summary>
    [Required]
    public DateTime MitgliedSeit { get; set; }

    /// <summary>
    /// Ausgeschieden am
    /// </summary>
    public DateTime? AusgeschiedenAm { get; set; }

    /// <summary>
    /// Ehemaliger
    /// </summary>
    public bool Ehemaliger { get; set; }

    /// <summary>
    /// Email Adresse
    /// </summary>
    [MaxLength(100)]
    public string? Email { get; set; }

    /// <summary>
    /// Faxnummer
    /// </summary>
    [MaxLength(50)]
    public string? Fax { get; set; }

    /// <summary>
    /// Geburtsdatum
    /// </summary>
    public DateTime Geburtsdatum { get; set; }

    /// <summary>
    /// Holz gesamt
    /// </summary>
    public int? HolzGes { get; set; }

    /// <summary>
    /// Holz max. an einem Abend
    /// </summary>
    public int? HolzMax { get; set; }

    /// <summary>
    /// Holz min an einem Abend
    /// </summary>
    public int? HolzMin { get; set; }

    /// <summary>
    /// Ort
    /// </summary>
    [MaxLength(50)]
    public string? Ort { get; set; }

    /// <summary>
    /// Passiv seit
    /// </summary>
    public DateTime? PassivSeit { get; set; }

    /// <summary>
    /// Platz
    /// </summary>
    [MaxLength(255)]
    public string? Platz { get; set; }

    /// <summary>
    /// PLZ
    /// </summary>
    [MinLength(5)]
    [MaxLength(5)]
    public string? PLZ { get; set; }

    /// <summary>
    /// Punkte Meisterschaft
    /// </summary>
    public int? Punkte { get; set; }

    /// <summary>
    /// Anzahl Teilnahmen an Meisterschaften
    /// </summary>
    public int? SpAnz { get; set; }

    /// <summary>
    /// Anzahl gewonnen
    /// </summary>
    public int? SpGew { get; set; }

    /// <summary>
    /// Anzahl unentschieden
    /// </summary>
    public int? SpUn { get; set; }

    /// <summary>
    /// Anzahl verloren
    /// </summary>
    public int? SpVerl { get; set; }

    /// <summary>
    /// Spitzname
    /// </summary>
    [MaxLength(50)]
    public string? Spitzname { get; set; }

    /// <summary>
    /// Straße
    /// </summary>
    [MaxLength(50)]
    public string? Straße { get; set; }

    /// <summary>
    /// Telefonnummer in der Firma
    /// </summary>
    [MaxLength(50)]
    public string? TelefonFirma { get; set; }

    /// <summary>
    /// Mobilnummer
    /// </summary>
    [MaxLength(50)]
    public string? TelefonMobil { get; set; }

    /// <summary>
    /// Festnetz
    /// </summary>
    [MaxLength(50)]
    public string? TelefonPrivat { get; set; }

    /// <summary>
    /// TurboDB ID
    /// </summary>
    public string? TurboDbnummer { get; set; }

    /// <summary>
    /// Bemerkungen
    /// </summary>
    public string? Bemerkungen { get; set; }

    /// <summary>
    /// Notizen
    /// </summary>
    public string? Notizen { get; set; }
}

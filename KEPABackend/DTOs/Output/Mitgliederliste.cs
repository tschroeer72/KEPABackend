using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Get;

/// <summary>
/// DTO Get Mitgliederliste
/// </summary>
public class Mitgliederliste
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Vorname
    /// </summary>
    public string Vorname { get; set; } = default!;

    /// <summary>
    /// Nachname
    /// </summary>
    public string Nachname { get; set; } = default!;

    /// <summary>
    /// Anrede
    /// </summary>
    public string? Anrede { get; set; }


    /// <summary>
    /// Mitglied seit
    /// </summary>
    public DateTime MitgliedSeit { get; set; }

    /// <summary>
    /// Ausgeschieden am
    /// </summary>
    public DateTime? AusgeschiedenAm { get; set; }

    /// <summary>
    /// Ehemaliger
    /// </summary>
    public ulong? Ehemaltiger { get; set; }

    /// <summary>
    /// Email Adresse
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Faxnummer
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Geburtsdatum
    /// </summary>
    public DateTime? Geburtsdatum { get; set; }

    /// <summary>
    /// Ort
    /// </summary>
    public string? Ort { get; set; }

    /// <summary>
    /// Passiv seit
    /// </summary>
    public DateTime? PassivSeit { get; set; }

    /// <summary>
    /// PLZ
    /// </summary>
    public string? PLZ { get; set; }

    /// <summary>
    /// Spitzname
    /// </summary>
    public string? Spitzname { get; set; }

    /// <summary>
    /// Straße
    /// </summary>
    public string? Straße { get; set; }

    /// <summary>
    /// Telefonnummer in der Firma
    /// </summary>
    public string? TelefonFirma { get; set; }

    /// <summary>
    /// Mobilnummer
    /// </summary>
    public string? TelefonMobil { get; set; }

    /// <summary>
    /// Festnetznummer
    /// </summary>
    public string? TelefonPrivat { get; set; }

    /// <summary>
    /// Bemerkungen
    /// </summary>
    public string? Bemerkungen { get; set; }

    /// <summary>
    /// NOtizen
    /// </summary>
    public string? Notizen { get; set; }
}

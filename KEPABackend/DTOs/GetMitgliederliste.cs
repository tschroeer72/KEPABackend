using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs;

public class GetMitgliederliste
{
    public int ID { get; set; }
    public string Vorname { get; set; } = default!;
    public string Nachname { get; set; } = default!;
    public string? Anrede { get; set; }
    public DateTime MitgliedSeit { get; set; }
    public DateTime? AusgeschiedenAm { get; set; }
    public string? Email { get; set; }
    public string? Fax { get; set; }
    public DateTime? Geburtsdatum { get; set; }
    public string? Ort { get; set; }
    public DateTime? PassivSeit { get; set; }
    public string? PLZ { get; set; }
    public string? Spitzname { get; set; }
    public string? Straße { get; set; }
    public string? TelefonFirma { get; set; }
    public string? TelefonMobil { get; set; }
    public string? TelefonPrivat { get; set; }
    public string? Bemerkungen { get; set; }
    public string? Notizen { get; set; }
}

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get NeuerRatten (Änderungen)
/// </summary>
public record vwNeunerRatten
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int NeunerRattenID { get; set; }

    /// <summary>
    /// MeisterschaftsID
    /// </summary>
    public int MeisterschaftsID { get; set; }

    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// Spieltag
    /// </summary>
    public DateTime Spieltag { get; set; }

    /// <summary>
    /// SpielerID
    /// </summary>
    public int SpielerID { get; set; }

    /// <summary>
    /// Vorname
    /// </summary>
    public string Vorname { get; set; } = default!;

    /// <summary>
    /// Nachname
    /// </summary>
    public string Nachname { get; set; } = default!;

    /// <summary>
    /// SPitzname
    /// </summary>
    public string Spitzname { get; set; } = default!;

    /// <summary>
    /// Geschobene Neuner
    /// </summary>
    public int Neuner { get; set; }

    /// <summary>
    /// Geschobene Ratten
    /// </summary>
    public int Ratten { get; set; }
}

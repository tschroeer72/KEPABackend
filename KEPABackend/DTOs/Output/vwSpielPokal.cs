namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get NeuerRatten (Änderungen)
/// </summary>
public record vwSpielPokal
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int SpielPokalID { get; set; }

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
    public string Vorname { get; set; }

    /// <summary>
    /// Nachname 
    /// </summary>
    public string Nachname { get; set; }

    /// <summary>
    /// Spitzname 
    /// </summary>
    public string Spitzname { get; set; }

    /// <summary>
    /// Platzierung
    /// </summary>
    public int Platzierung { get; set; }
}

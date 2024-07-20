namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get vwSpielSargkegeln
/// </summary>
public record vwSpielSargkegeln
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int SpielSargkegelnID { get; set; }

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

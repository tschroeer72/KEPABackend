namespace KEPABackend.DTOs.Get;

/// <summary>
/// DTO Get NeuerRatten (Änderungen)
/// </summary>
public record NeunerRatten
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int ID { get; set; } = default!;

    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID
    /// </summary>
    public int SpielerID { get; set; }

    /// <summary>
    /// Geschobene Neuner
    /// </summary>
    public int Neuner { get; set; }

    /// <summary>
    /// Geschobene Ratten
    /// </summary>
    public int Ratten { get; set; }
}

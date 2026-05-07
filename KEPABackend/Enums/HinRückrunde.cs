using HotChocolate;

namespace KEPABackend.Enums;

/// <summary>
/// Enum für Hin-/Rückrunde
/// </summary>
[GraphQLName("HinRueckrunde")]
public enum HinRückrunde
{
    /// <summary>
    /// Hinrunde
    /// </summary>
    [GraphQLName("HINRUNDE")]
    Hinrunde = 0,

    /// <summary>
    /// Rückrunde
    /// </summary>
    [GraphQLName("RUECKRUNDE")]
    Rückrunde = 1
}

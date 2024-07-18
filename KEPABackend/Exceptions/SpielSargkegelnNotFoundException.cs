using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielSargkegelnNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class SpielSargkegelnNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielSargkegelnNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielSargkegelnNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielSargkegelnNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielSargkegelnNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

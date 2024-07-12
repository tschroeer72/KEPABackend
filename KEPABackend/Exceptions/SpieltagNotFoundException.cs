using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Spieltag not found
/// </summary>
[Serializable]
public class SpieltagNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpieltagNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpieltagNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpieltagNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpieltagNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

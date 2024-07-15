using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Spieltag not found
/// </summary>
[Serializable]
public class SpieltagInUseException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpieltagInUseException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpieltagInUseException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpieltagInUseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpieltagInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

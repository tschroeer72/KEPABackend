using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Spieltag existiert bereits
/// </summary>
[Serializable]
public class SpieltagAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpieltagAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpieltagAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpieltagAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpieltagAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielKombimeisterschaftAlreadyExistsException existiert bereits
/// </summary>
[Serializable]
public class SpielKombimeisterschaftAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielKombimeisterschaftAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielKombimeisterschaftAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielKombimeisterschaftAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielKombimeisterschaftAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

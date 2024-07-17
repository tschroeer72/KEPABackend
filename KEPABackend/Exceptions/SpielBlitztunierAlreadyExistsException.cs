using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielBlitztunierAlreadyExistsException existiert bereits
/// </summary>
[Serializable]
public class SpielBlitztunierAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielBlitztunierAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielBlitztunierAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielBlitztunierAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielBlitztunierAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

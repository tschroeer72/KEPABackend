using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielMeisterschaftAlreadyExistsException existiert bereits
/// </summary>
[Serializable]
public class SpielMeisterschaftAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielMeisterschaftAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielMeisterschaftAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielMeisterschaftAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielMeisterschaftAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

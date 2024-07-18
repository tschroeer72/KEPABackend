using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielMeisterschaftAlreadyExistsException existiert bereits
/// </summary>
[Serializable]
public class SpielPokalAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielPokalAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielPokalAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielPokalAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielPokalAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

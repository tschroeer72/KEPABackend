using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielSargkegelnAlreadyExistsException existiert bereits
/// </summary>
[Serializable]
public class SpielSargkegelnAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielSargkegelnAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielSargkegelnAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielSargkegelnAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielSargkegelnAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

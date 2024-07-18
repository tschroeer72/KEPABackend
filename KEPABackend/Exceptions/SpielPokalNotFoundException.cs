using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielPokalNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class SpielPokalNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielPokalNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielPokalNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielPokalNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielPokalNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

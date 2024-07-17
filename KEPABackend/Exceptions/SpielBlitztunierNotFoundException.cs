using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielBlitztunierNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class SpielBlitztunierNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielBlitztunierNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielBlitztunierNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielBlitztunierNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielBlitztunierNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielKombimeisterschaftNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class SpielKombimeisterschaftNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielKombimeisterschaftNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielKombimeisterschaftNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielKombimeisterschaftNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielKombimeisterschaftNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

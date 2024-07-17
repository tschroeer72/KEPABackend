using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception SpielMeisterschaftNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class SpielMeisterschaftNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielMeisterschaftNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public SpielMeisterschaftNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public SpielMeisterschaftNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected SpielMeisterschaftNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

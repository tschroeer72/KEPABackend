using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception NeunerRatten nicht gefunden
/// </summary>
[Serializable]
public class NeunerRattenNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NeunerRattenNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public NeunerRattenNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public NeunerRattenNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected NeunerRattenNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception NeunerRatten existiert bereits
/// </summary>
[Serializable]
public class NeunerRattenAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NeunerRattenAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public NeunerRattenAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public NeunerRattenAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected NeunerRattenAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

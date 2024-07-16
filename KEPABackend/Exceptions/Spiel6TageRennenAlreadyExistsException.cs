using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception NeunerRatten existiert bereits
/// </summary>
[Serializable]
public class Spiel6TageRennenAlreadyExistsException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public Spiel6TageRennenAlreadyExistsException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public Spiel6TageRennenAlreadyExistsException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public Spiel6TageRennenAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected Spiel6TageRennenAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

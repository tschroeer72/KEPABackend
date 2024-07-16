using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Spiel6TageRennenNotFoundException nicht gefunden
/// </summary>
[Serializable]
public class Spiel6TageRennenNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public Spiel6TageRennenNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public Spiel6TageRennenNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public Spiel6TageRennenNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected Spiel6TageRennenNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

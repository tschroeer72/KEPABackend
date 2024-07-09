using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Mitglied not found
/// </summary>
[Serializable]
public class MitgliedNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MitgliedNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public MitgliedNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public MitgliedNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MitgliedNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

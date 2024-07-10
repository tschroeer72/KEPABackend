using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Meisterschaft not found
/// </summary>
[Serializable]
public class MeisterschaftNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public MeisterschaftNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public MeisterschaftNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MeisterschaftNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Meisterschaftstyp not found
/// </summary>
[Serializable]
public class MeisterschaftstypNotFoundException : Exception
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftstypNotFoundException()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    public MeisterschaftstypNotFoundException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public MeisterschaftstypNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MeisterschaftstypNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

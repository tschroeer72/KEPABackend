using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

/// <summary>
/// Exception Meisterschaftstyp not found
/// </summary>
[Serializable]
public class MeisterschaftstypNotFoundException : Exception
{
    public MeisterschaftstypNotFoundException()
    {
    }

    public MeisterschaftstypNotFoundException(string? message) : base(message)
    {
    }

    public MeisterschaftstypNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MeisterschaftstypNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

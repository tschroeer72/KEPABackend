using System.Runtime.Serialization;

namespace KEPABackend.Exceptions;

[Serializable]
public class MitgliedNotFoundException : Exception
{
    public MitgliedNotFoundException()
    {
    }

    public MitgliedNotFoundException(string? message) : base(message)
    {
    }

    public MitgliedNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MitgliedNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

namespace APBD_LAB3.Exeption;

public class OverfillException : Exception
{
    public override string Message { get; }

    public OverfillException(string message) : base(message)
    {
        Message = message;
    }
}
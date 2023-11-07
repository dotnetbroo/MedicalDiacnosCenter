namespace MedicalDiacnosCenter.Service.Exceptions;

public class CostumException : Exception
{
    public int StatusCode { get; set; }

    public CostumException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}

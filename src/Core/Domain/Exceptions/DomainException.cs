namespace Domain.Exceptions;

public abstract class DomainException : ApplicationException
{
    protected DomainException(string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        //HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        params string[] errors)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public IEnumerable<string> ErrorMessages { get; protected set; }

    public HttpStatusCode StatusCode { get; protected set; }
}

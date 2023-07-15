using FluentValidation.Results;
using System.ComponentModel;

namespace Application.Common.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException()
        : base("one or more validation failures have occured.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(f => f.Key, f => f.ToArray());
    }


    public IDictionary<string, string[]> Errors { get; }
}

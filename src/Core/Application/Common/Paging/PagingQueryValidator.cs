using Domain.Base;

namespace Application.Common.Paging;

public class PagingQueryValidator<T, TF> : AbstractValidator<T>
    where T : BaseFilterPageVM<TF> where TF: class, new()
{
    protected PagingQueryValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThanOrEqualTo(1).WithMessage("PageIndex at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}

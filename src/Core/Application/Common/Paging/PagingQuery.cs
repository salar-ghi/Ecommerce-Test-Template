namespace Application.Common.Paging;

public class PagingQuery<TM>
{
    protected PagingQuery(IPageContext<TM> pageContext) => PageContext = pageContext;

    public IPageContext<TM> PageContext { get; set; }
}

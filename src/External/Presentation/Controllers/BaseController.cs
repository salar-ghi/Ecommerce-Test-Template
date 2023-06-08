namespace Presentation.Rest.Controllers;


[ApiController]
[Produces("application/json")]
public abstract class BaseController : ControllerBase
{
    //protected BaseController(IMediator mediator) => Mediator = mediator.ThrowIfNull();
    //protected IMediator Mediator { get; }

    //public BaseController(IMediator mediator) => _mediator = mediator;
    //{
    //    _mediator = mediator;
    //}


    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

}

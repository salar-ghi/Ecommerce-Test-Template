 namespace Presentation.Rest.Controllers.Version1;

[ApiVersion(VersionController.Version1)]
[Route("api/v{version:apiVersion}/category")]
public class CategoryControllerV1 : BaseController
{
    public async Task<ActionResult<ResultDto<long>>> Create(
        [FromBody] CreateCategoryCommand command, CancellationToken ct)
        => (await Mediator.Send(command, ct)).ToResultDto();


}

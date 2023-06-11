namespace Presentation.Rest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<PaginitionResDto<List<CategoryResDto>>> GetCategories()
    {
        return await _sender.Send(new GetCategoryListQuery());
        //var categoryResult = await _sender.Send(new GetCategoryListQuery());
    }


    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryResDto>> GetCategoryById(CategoryId Id)
    {
        var categroyResult = await _sender.Send(new GetCategoryQuery(Id));
        return categroyResult == null ? NotFound() : Ok(categroyResult);
        
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<ActionResult<CategoryResDto>> CreateCategory(CreateCategoryCommand command, CancellationToken ct)
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command, CancellationToken ct)
    {
        await _sender.Send(command);

        return CreatedAtAction(nameof(GetCategoryById), ControllerNameConstants.Category, new { id = command.Id }, command);

    }



}

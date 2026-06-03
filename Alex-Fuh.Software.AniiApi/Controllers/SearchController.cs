using Alex_Fuh.Software.AniiApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alex_Fuh.Software.AniiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> SearchAnime([FromQuery] string search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return BadRequest("Search darf nicht leer sein.");
        }

        var result = await _searchService.SearchAsync(search);

        return Content(result, "application/json");
    }
}
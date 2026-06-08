using Alex_Fuh.Software.AniiApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alex_Fuh.Software.AniiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;
    
    public DashboardController(IDashboardService dashboardService)
        {
        _dashboardService = dashboardService;
        }

    [HttpGet]
    public async Task<IActionResult> LoadForFrontPage(int from, int to)
    {
        var result = await _dashboardService.LoadingTitelsForFrontPageAsync(from, to);
        return Content(result, "application/json");
    }
}
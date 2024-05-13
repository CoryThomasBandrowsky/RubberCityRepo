using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubberCity.Services.Services;

namespace RubberCityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(DashboardService userService, ILogger<DashboardController> logger)
        {
            _dashboardService = userService;
            _logger = logger;
        }

        [HttpGet("/helpers/dashboard")]
        public async Task<IActionResult> GetAllDashboardResults(string id)
        {
            await _dashboardService.GetAllDashboardResults(id);
            return CreatedAtAction(nameof(GetAllDashboardResults), new { id = user.ID }, user);
        }

    }
}

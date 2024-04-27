using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RubberCity.Services.Services;
using RubberCityAPI.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        #region members
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;
        #endregion members
        #region controller
        public HomeController(IOptionsSnapshot<AppSettings> appSettings,
            ILogger<HomeController> logger,
            UserService userService)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }
        #endregion controller
        #region functions

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new TestResponse("dad time");
            return Ok(response);
        }
        #endregion functions
    }
}

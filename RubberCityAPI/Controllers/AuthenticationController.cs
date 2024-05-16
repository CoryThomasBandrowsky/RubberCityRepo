using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubberCity.Services.Services;

namespace RubberCityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authService;

        public AuthenticationController(AuthenticationService authService)
        {
            _authService = authService;
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            var result = await _authService.ValidateUser(request);

            if (result.valid)
            {
                // User authenticated successfully
                return Ok(new { valid = result.valid, user = result.user });
            }
            else
            {
                // Authentication failed
                return Unauthorized("Invalid credentials");
            }
        }
    }
}

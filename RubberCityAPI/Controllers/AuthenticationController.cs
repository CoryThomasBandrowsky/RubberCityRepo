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

        public IActionResult Login(AuthenticationRequest request)
        {
            if (_authService.ValidateUser(request))
            {
                // User authenticated successfully
                return Ok("Login successful");
            }
            else
            {
                // Authentication failed
                return Unauthorized("Invalid credentials");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using RubberCity.Services.Services;
using System.Threading.Tasks;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: /Users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }

        // GET: /Users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // POST: /Users
        [HttpPost("/users/add")]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.ID }, user);
        }

        // PUT: /Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.ID)
            {
                return BadRequest("User ID mismatch");
            }

            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE: /Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.DeleteUserAsync(user);
            return NoContent();
        }

        [HttpPost("saveProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file, [FromForm] int userId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var uploads = Path.Combine("D:\\RubberCityRepo\\WWWRubberCityFoundation\\src\\assets", "profile-pictures");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            user.ImagePath = "assets/profile-pictures/" + file.FileName;
            await _userService.UpdateUserAsync(user);

            return Ok(user);
        }
    }
}

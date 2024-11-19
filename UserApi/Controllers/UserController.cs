using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserApi.BusinessLogicalLayer.Interface.Services;
using UserApi.DataAccessLayer.Entities;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // Метод для створення нового користувача
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] Users user)
        {
            try
            {
                await userService.CreateUserAsync(user);
                return Ok(new { message = "User created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckIfEmailExists([FromQuery] string email)
        {
            var exists = await userService.CheckIfEmailExistsAsync(email);
            return Ok(new { emailExists = exists });
        }

        [HttpGet("check-username")]
        public async Task<IActionResult> CheckIfUsernameExists([FromQuery] string username)
        {
            var exists = await userService.CheckIfUsernameExistsAsync(username);
            return Ok(new { usernameExists = exists });
        }
    }
}

using GroceryApp.Models;
using GroceryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApp.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto dto)
        {
            var token = _auth.Login(dto);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }
    }
}

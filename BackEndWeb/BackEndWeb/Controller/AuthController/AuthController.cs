using Microsoft.AspNetCore.Mvc;

namespace BackEndWeb.Controller.AuthController;

[ApiController]
[Route("api/[controller]")] //api/AuthController/login
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Console.WriteLine("Выполнение Авторизации");
        // Валидация, аутентификация, и т.д.
        if (request.Username == "user" && request.Password == "password")
        {
            return Ok(new { message = "Login successful" });
        }
        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
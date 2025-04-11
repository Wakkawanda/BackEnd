using Microsoft.AspNetCore.Mvc;

namespace BackEndWeb.Controller.AuthController;

[ApiController]
[Route("api/[controller]")] //api/AuthController/login
public class AuthController : ControllerBase
{
    LDAP ld = new LDAP();
    
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Console.WriteLine("Выполнение Авторизации");
        
        if (ld.LDAPConn(request.Username, request.Password))
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
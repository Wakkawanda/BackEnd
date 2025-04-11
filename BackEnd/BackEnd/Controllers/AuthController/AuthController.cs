using BackEnd.Models.UserModel;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers.AuthController;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private static readonly List<UserModel> _users = new List<UserModel>();
    
    [HttpPost("login")]
    public IActionResult Login(UserModel user)
    {
        // 1. Валидация
        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            return BadRequest("Username и Password обязательны");
        }

        // 2. Поиск пользователя
        var foundUser = _users.FirstOrDefault(u => u.Username == user.Username);
        if (foundUser == null)
        {
            return NotFound("Пользователь не найден"); // Или Unauthorized
        }

        // 3. Проверка пароля
        if (user.PasswordHash == foundUser.PasswordHash)
        {
            return Unauthorized("Неверный пароль");
        }
        Console.WriteLine($"Выполнен вход: {foundUser.Username}");

        // 4. Возврат успешного результата
        return Ok(new { message = "Вход выполнен успешно" }); // Или можно вернуть токен, но для простоты пока так
    }
    
    
}
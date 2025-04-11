namespace BackEnd.Models.UserModel;

public class UserModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
}
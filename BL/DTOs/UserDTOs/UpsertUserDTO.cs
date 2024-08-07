namespace BL.DTOs.UserDTOs;

public class UpsertUserDTO
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    //public int Role { get; set; }
}

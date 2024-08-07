namespace BL.DTOs.UserDTOs;

public class GetUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public int Role { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace DL.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public int Role { get; set; }
}

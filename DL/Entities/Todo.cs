using System.ComponentModel.DataAnnotations;

namespace DL.Entities;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}

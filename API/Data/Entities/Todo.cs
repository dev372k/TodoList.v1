using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}

namespace API.DTOs;

public class GetTodoDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}

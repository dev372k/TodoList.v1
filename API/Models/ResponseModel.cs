namespace API.Models;

public class ResponseModel
{
    public bool Status { get; set; } = true;
    public string Message { get; set; } = String.Empty;
    public object Data { get; set; } = new { };
}

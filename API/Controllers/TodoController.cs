using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private static List<Todo> todos = new List<Todo>();

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(new ResponseModel { Data = todos });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
            return Ok(new ResponseModel { Data = todo });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Post(Todo request)
    {
        try
        {
            todos.Add(request);
            return Ok(new ResponseModel { Message = "Todo added successfully.", Data = request });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }
 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var todo = todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                throw new Exception("There is no such todo found.");

            todos.Remove(todo);
            return Ok(new ResponseModel { Message = "Todo deleted successfully." });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }
}

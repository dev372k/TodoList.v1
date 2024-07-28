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
            var todo = todos.FirstOrDefault(_ => _.Id == id);
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
            var todo = todos.Any();
            if (todo == false)
            {
                request.Id = 1;
            }
            else
            {
                var todoList = todos.OrderByDescending(_ => _.Id).FirstOrDefault();
                request.Id = todoList.Id + 1;
            }

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
            var todo = todos.FirstOrDefault(_ => _.Id == id);
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

    //[HttpPut]
    //public IActionResult Put(Todo request)
    //{
    //    try
    //    {
    //        var todo = todos.FirstOrDefault(x => x.Id == request.Id);
    //        if (todo == null)
    //            throw new Exception("There is no such todo found.");

    //        todo.Title = request.Title;
    //        todo.Description = request.Description;
    //        return Ok(new ResponseModel { Message = "Todo updated successfully." });
    //    }
    //    catch (Exception ex)
    //    {
    //        return Ok(new ResponseModel { Status = false, Message = ex.Message });
    //    }
    //}

    [HttpPut("{id}")]
    public IActionResult Put(int id, Todo request)
    {
        try
        {
            var todo = todos.FirstOrDefault(_ => _.Id == id);
            if (todo == null)
                throw new Exception("There is no such todo found.");

            todo.Title = request.Title;
            todo.Description = request.Description;
            return Ok(new ResponseModel { Message = "Todo updated successfully." });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }
}

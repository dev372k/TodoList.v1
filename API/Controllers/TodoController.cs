using API.DTOs;
using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var todos = _todoService.Get();
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
            var todo = _todoService.Get(id);
            return Ok(new ResponseModel { Data = todo });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Post(AddTodoDTO request)
    {
        try
        {
            var todo = _todoService.Post(request);
            return Ok(new ResponseModel { Message = "Todo added successfully.", Data = todo });
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
            _todoService.Delete(id);
            return Ok(new ResponseModel { Message = "Todo deleted successfully." });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseModel { Status = false, Message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateTodoDTO request)
    {
        try
        {
            var todo = _todoService.Put(id, request);
            return Ok(new ResponseModel { Message = "Todo updated successfully.", Data = todo });
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
}

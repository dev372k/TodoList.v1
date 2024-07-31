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
            return Ok(new ResponseModel { Data = _todoService.Get() });
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
            return Ok(new ResponseModel { Data = _todoService.Get(id) });
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
            return Ok(new ResponseModel { Message = "Todo added successfully.", Data = _todoService.Post(request) });
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
            return Ok(new ResponseModel { Message = "Todo updated successfully.", Data = _todoService.Put(id, request) });
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

using API.Models;
using BL.DTOs;
using BL.Services.Interfaces;
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
    public IActionResult Get() =>
        Ok(new ResponseModel { Data = _todoService.Get() });

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _todoService.Get(id) });

    [HttpPost]
    public IActionResult Post(AddTodoDTO request) =>
        Ok(new ResponseModel { Message = "Todo added successfully.", Data = _todoService.Post(request) });

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _todoService.Delete(id);
        return Ok(new ResponseModel { Message = "Todo deleted successfully." });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateTodoDTO request)
        => Ok(new ResponseModel { Message = "Todo updated successfully.", Data = _todoService.Put(id, request) });

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

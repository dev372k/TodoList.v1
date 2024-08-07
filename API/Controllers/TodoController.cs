using API.Models;
using BL.DTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet, Authorize]
    public IActionResult Get() =>
        Ok(new ResponseModel { Data = _todoService.GetAll() });

    [HttpGet("{id:int}"), Authorize]
    public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _todoService.Get(id) });
    
    [HttpGet("{userId:int}/user"), Authorize]
    public IActionResult GetAll(int userId) =>
        Ok(new ResponseModel { Data = _todoService.GetAll(userId) });

    [HttpPost, Authorize]
    public IActionResult Post(AddTodoDTO request) =>
        Ok(new ResponseModel { Message = "Todo added successfully.", Data = _todoService.Post(request) });

    [HttpDelete("{id}"), Authorize]
    public IActionResult Delete(int id)
    {
        _todoService.Delete(id);
        return Ok(new ResponseModel { Message = "Todo deleted successfully." });
    }

    [HttpPut("{id}"), Authorize]
    public IActionResult Put(int id, UpdateTodoDTO request)
        => Ok(new ResponseModel { Message = "Todo updated successfully.", Data = _todoService.Put(id, request) });
}

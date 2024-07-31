using API.Data;
using API.Data.Entities;
using API.DTOs;
using API.Services.Interfaces;

namespace API.Services.Implementations;

public class TodoService : ITodoService
{
    private ApplicationDBContext _context;

    public TodoService(ApplicationDBContext context)
    {
        _context = context;
    }

    public List<GetTodoDTO> Get()
    {
        var todos = _context.Todos.ToList();
        List<GetTodoDTO> todoList = new List<GetTodoDTO>();
        foreach (var todo in todos)
        {
            var newTodo = new GetTodoDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
            };
            todoList.Add(newTodo);
        }
        return todoList;
    }

    public GetTodoDTO Get(int id)
    {
        var todo = _context.Todos.FirstOrDefault(_ => _.Id == id) 
            ?? throw new Exception("There is no such todo found.");

        return new GetTodoDTO
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description
        };
    }

    public GetTodoDTO Post(AddTodoDTO dto)
    {
        var todo = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
        };

        _context.Todos.Add(todo);
        _context.SaveChanges();

        return new GetTodoDTO
        {
            Id = todo.Id,
            Title = dto.Title,
            Description = dto.Description,
        };
    }

    public void Delete(int id)
    {
        var todo = _context.Todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }

    public GetTodoDTO Put(int id, UpdateTodoDTO dto)
    {
        var todo = _context.Todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        todo.Title = dto.Title;
        todo.Description = dto.Description;

        _context.SaveChanges();

        return new GetTodoDTO
        {
            Id = todo.Id,
            Title = dto.Title,
            Description = dto.Description
        };
    }
}

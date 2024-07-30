using API.DTOs;
using API.Models;
using API.Services.Interfaces;

namespace API.Services.Implementations;

public class TodoService : ITodoService
{
    private static List<Todo> todos = new List<Todo>();
    public GetTodoDTO Post(AddTodoDTO dto)
    {
        int id = GenerateId();

        var todo = new Todo
        {
            Id = id,
            Title = dto.Title,
            Description = dto.Description,
        };
        todos.Add(todo);

        return new GetTodoDTO
        {
            Id = id,
            Title = dto.Title,
            Description = dto.Description,
        };
    }

    public void Delete(int id)
    {
        var todo = todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        todos.Remove(todo);
    }

    public List<GetTodoDTO> Get()
    {
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
        var todo = todos.FirstOrDefault(_ => _.Id == id) ?? throw new Exception("There is no such todo found."); ;
        return new GetTodoDTO
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description
        };
    }

    public GetTodoDTO Put(int id, UpdateTodoDTO dto)
    {
        var todo = todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        todo.Title = dto.Title;
        todo.Description = dto.Description;

        return new GetTodoDTO
        {
            Id = todo.Id,
            Title = dto.Title,
            Description = dto.Description
        };
    }

    private int GenerateId()
    {
        var todo = todos.Any();
        if (todo == false)
        {
            return 1;
        }
        else
        {
            var todoList = todos.OrderByDescending(_ => _.Id).FirstOrDefault();
            return todoList.Id + 1;
        }
    }
}

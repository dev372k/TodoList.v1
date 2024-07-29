using API.Models;
using API.Services.Interfaces;

namespace API.Services.Implementations;

public class TodoService : ITodoService
{
    private static List<Todo> todos = new List<Todo>();
    public Todo Post(Todo dto)
    {
        var todo = todos.Any();
        if (todo == false)
        {
            dto.Id = 1;
        }
        else
        {
            var todoList = todos.OrderByDescending(_ => _.Id).FirstOrDefault();
            dto.Id = todoList.Id + 1;
        }

        todos.Add(dto);

        return dto;
    }

    public void Delete(int id)
    {
        var todo = todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        todos.Remove(todo);
    }

    public List<Todo> Get()
    {
        return todos;
    }

    public Todo Get(int id)
    {
        var todo = todos.FirstOrDefault(_ => _.Id == id);
        return todo;
    }

    public Todo Put(int id, Todo dto)
    {
        var todo = todos.FirstOrDefault(_ => _.Id == id);
        if (todo == null)
            throw new Exception("There is no such todo found.");

        todo.Title = dto.Title;
        todo.Description = dto.Description;
        return todo;
    }
}

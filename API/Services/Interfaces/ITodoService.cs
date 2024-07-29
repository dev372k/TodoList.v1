using API.Models;

namespace API.Services.Interfaces;

public interface ITodoService
{
    List<Todo> Get();
    Todo Get(int id);
    Todo Post(Todo dto);
    Todo Put(int id, Todo dto);
    void Delete(int id);
}

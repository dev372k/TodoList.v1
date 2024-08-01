using BL.DTOs;

namespace BL.Services.Interfaces;

public interface ITodoService
{
    List<GetTodoDTO> Get();
    GetTodoDTO Get(int id);
    GetTodoDTO Post(AddTodoDTO dto);
    GetTodoDTO Put(int id, UpdateTodoDTO dto);
    void Delete(int id);
}

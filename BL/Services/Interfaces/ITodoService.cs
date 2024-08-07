using BL.DTOs;

namespace BL.Services.Interfaces;

public interface ITodoService
{
    List<GetTodoDTO> GetAll();
    List<GetTodoDTO> GetAll(int userid);
    GetTodoDTO Get(int id);
    GetTodoDTO Post(AddTodoDTO dto);
    GetTodoDTO Put(int id, UpdateTodoDTO dto);
    void Delete(int id);
}

using BL.DTOs.UserDTOs;

namespace BL.Services.Interfaces;

public interface IUserService
{
    GetUserDTO Add(UpsertUserDTO dto);
    GetUserDTO Get(int id);
    GetUserDTO Get(string email);
    GetUserDTO Login(string email, string password);
}

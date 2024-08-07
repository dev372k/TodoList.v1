using BL.DTOs.UserDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using Shared.Helpers;

namespace BL.Services.Implementations;

public class UserService : IUserService
{
    private ApplicationDBContext _context;

    public UserService(ApplicationDBContext context)
    {
        _context = context;
    }

    public GetUserDTO Add(UpsertUserDTO dto)
    {
        var user = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            Role = 1,
            PasswordHash = SecurityHelper.GenerateHash(dto.Password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return new GetUserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role,
        };
    }

    public GetUserDTO Get(int id) => _context.Users.Select(_ => new GetUserDTO
    {
        Id = _.Id,
        Email = _.Email,
        Name = _.Name,
        Role = _.Role,
    }).FirstOrDefault(_ => _.Id == id) ?? throw new Exception("There is no such user found.");

    public GetUserDTO Get(string email) => _context.Users.Select(_ => new GetUserDTO
    {
        Id = _.Id,
        Email = _.Email,
        Name = _.Name,
        Role = _.Role,
    }).FirstOrDefault(_ => _.Email == email) ?? throw new Exception("There is no such user found.");

    public GetUserDTO Login(string email, string password)
    {
        var user = Get(email, password);

        return new GetUserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role,
        };
    }

    private GetUserDTO Get(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(_ => _.Email == email);
        if (user == null)
            throw new Exception("User not found.");
        else if(!SecurityHelper.ValidateHash(password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return new GetUserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role,
        };
    }
}

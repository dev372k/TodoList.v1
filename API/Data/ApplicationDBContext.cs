using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt) { }

    public DbSet<Todo> Todos { get; set; }
}

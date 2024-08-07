﻿using DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}

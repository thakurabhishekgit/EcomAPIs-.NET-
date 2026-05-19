
using EcommerceApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Product> Products => Set<Product>();
}
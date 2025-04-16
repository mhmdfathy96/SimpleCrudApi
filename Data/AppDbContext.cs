using Microsoft.EntityFrameworkCore;
using SimpleCrudApi.Models;
namespace SimpleCrudApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
}

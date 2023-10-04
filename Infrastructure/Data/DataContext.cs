using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)=>Database.EnsureCreated();

    public DbSet<Student> Students { get; set; }
}

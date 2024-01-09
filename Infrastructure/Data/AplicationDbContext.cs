using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AplicationDbContext:DbContext
{
     public AplicationDbContext(DbContextOptions<AplicationDbContext> op):base(op)
    {
        
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    
}

using Microsoft.EntityFrameworkCore;
using Domain.Models;

public class RubberCityContext : DbContext
{
    public RubberCityContext(DbContextOptions<RubberCityContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }
}
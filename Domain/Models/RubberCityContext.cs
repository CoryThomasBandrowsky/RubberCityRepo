using Microsoft.EntityFrameworkCore;
using Domain.Models;

public class RubberCityContext : DbContext
{
    public RubberCityContext(DbContextOptions<RubberCityContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<HelpRequestModel> HelpRequests { get; set; }
    public DbSet<UserMessage> UserMessage { get; set; }
    public DbSet<Case> Case { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Donation> Donations { get; set; }
}
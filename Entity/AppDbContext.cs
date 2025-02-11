using Microsoft.EntityFrameworkCore;

namespace Entity;

public  class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<TimeEntry> TimeEntries { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Shift> Shifts { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>()
            .HasMany(w => w.Shifts)
            .WithOne(s => s.Worker)
            .HasForeignKey(s => s.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Shift>()
            .Property(s => s.StartTime)
            .IsRequired();

        modelBuilder.Entity<Shift>()
            .Property(s => s.EndTime)
            .IsRequired();
    }
}

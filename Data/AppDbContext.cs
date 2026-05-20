using EcommerceApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EcommerceApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        ApplyDateTimeLogic();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyDateTimeLogic();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyDateTimeLogic()
    {
        var istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        var entries = ChangeTracker.Entries<User>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                entry.Entity.CreatedAtIST = ConvertToIST(entry.Entity.CreatedAt, istZone);
                entry.Entity.UpdatedAtIST = ConvertToIST(entry.Entity.UpdatedAt, istZone);
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                entry.Entity.UpdatedAtIST = ConvertToIST(entry.Entity.UpdatedAt, istZone);
            }
        }
    }

    private string ConvertToIST(DateTime utcTime, TimeZoneInfo istZone)
    {
        var istTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, istZone);

        return istTime.ToString("dd MMM yyyy hh:mm tt", CultureInfo.InvariantCulture);
    }

    public DbSet<Product> Products => Set<Product>();
}

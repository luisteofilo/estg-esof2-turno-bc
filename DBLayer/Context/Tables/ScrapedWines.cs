using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildScrapedWines(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScrapedWine>()
            .Property(p => p.ScrapedWineId)
            .HasDefaultValueSql("gen_random_uuid()");
        modelBuilder.Entity<ScrapedWine>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("current_timestamp");
    }
}

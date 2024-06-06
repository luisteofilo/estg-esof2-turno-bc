using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildWineCategoryLinks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WineCategoryLink>()
            .Property(p => p.WineCategoryLinkId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<WineCategoryLink>()
            .HasOne(wcl => wcl.Wine)
            .WithMany()
            .HasForeignKey(wcl => wcl.WineId);

        modelBuilder.Entity<WineCategoryLink>()
            .Property(wcl => wcl.CategoryId)
            .HasConversion<int>();
    }
}
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildWines(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>()
            .Property(p => p.WineId)
            .HasDefaultValueSql("gen_random_uuid()");
    }
}
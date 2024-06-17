using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildWines(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>(entity =>
        {
            entity.HasKey(w => w.WineId);
            entity.Property(w => w.WineId).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(w => w.WineName).IsRequired();
        });
    }
}
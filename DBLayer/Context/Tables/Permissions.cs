using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildPermissions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>()
            .HasMany(p => p.RolePermissions)
            .WithOne(rp => rp.Permission)
            .HasForeignKey(rp => rp.PermissionId);
        
        modelBuilder.Entity<Permission>()
            .Property(p => p.PermissionId)
            .HasDefaultValueSql("gen_random_uuid()");
    }
}
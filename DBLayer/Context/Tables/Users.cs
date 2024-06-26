using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(e => new { e.RoleId, e.UserId });
    }
}
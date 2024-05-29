using DotNetEnv;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext : DbContext
{
    private static bool _envLoaded = false;
    
    public ApplicationDbContext()
    {
        if (_envLoaded) return;
        LoadEnvFile();
        _envLoaded = true;
    }
    
    private void LoadEnvFile()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var envFilePath = Path.Combine(currentDirectory, ".env");

        if (!File.Exists(envFilePath))
        {
            // Try loading from parent directory
            string? parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            if (parentDirectory != null) envFilePath = Path.Combine(parentDirectory, ".env");

            if (!File.Exists(envFilePath))
            {
                throw new FileNotFoundException("The .env file could not be found in the current or parent directory.");
            }
        }
        
        Console.WriteLine(envFilePath);

        Env.Load(envFilePath);
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var db = Env.GetString("POSTGRES_DB");
        var user = Env.GetString("POSTGRES_USER");
        var password = Env.GetString("POSTGRES_PASSWORD");
        var port = Env.GetString("POSTGRES_PORT");
        var host = Env.GetString("POSTGRES_HOST");

        if (string.IsNullOrEmpty(db) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(port) || string.IsNullOrEmpty(host))
        {
            throw new InvalidOperationException("Database connection information not fully specified in environment variables.");
        }
        
        var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildUsers(modelBuilder);
        BuildRoles(modelBuilder);
        BuildPermissions(modelBuilder);
        BuildRolePermissions(modelBuilder);
        BuildUserRoles(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}

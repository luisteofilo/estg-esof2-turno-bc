using System.Linq.Expressions;
using DotNetEnv;
using ESOF.WebApp.DBLayer.Entities;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext : DbContext
{
    private static readonly DbContextOptions DefaultOptions = new Func<DbContextOptions>(() =>
    {
        var optionsBuilder = new DbContextOptionsBuilder();
        var db = EnvFileHelper.GetString("POSTGRES_DB");
        var user = EnvFileHelper.GetString("POSTGRES_USER");
        var password = EnvFileHelper.GetString("POSTGRES_PASSWORD");
        var port = EnvFileHelper.GetString("POSTGRES_PORT");
        var host = EnvFileHelper.GetString("POSTGRES_HOST");

        if (string.IsNullOrEmpty(db) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(port) || string.IsNullOrEmpty(host))
        {
            throw new InvalidOperationException(
                "Database connection information not fully specified in environment variables.");
        }

        var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";
        optionsBuilder.UseNpgsql(connectionString);
        return optionsBuilder.Options;
    })();
    
    public ApplicationDbContext()
        : base(DefaultOptions)
    {
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
    public DbSet<Wine> Wines { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<GrapeType> GrapeTypes { get; set; }
    public DbSet<WineGrapeTypeLink> WineGrapeTypeLinks { get; set; }
    
    public DbSet<TasteQuestionType> TasteQuestionTypes { get; set; }
    public DbSet<TasteQuestion> TasteQuestions { get; set; }
    public DbSet<TasteEvaluation> TasteEvaluations { get; set; }
    public DbSet<TasteEvaluationQuestion> TasteEvaluationQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildUsers(modelBuilder);
        BuildRoles(modelBuilder);
        BuildPermissions(modelBuilder);
        BuildRolePermissions(modelBuilder);
        BuildUserRoles(modelBuilder);
        BuildWines(modelBuilder);
        BuildBrands(modelBuilder);
        BuildRegions(modelBuilder);
        BuildGrapeTypes(modelBuilder);
        BuildWineGrapeTypeLinks(modelBuilder);
        
        BuildTasteQuestionTypes(modelBuilder);
        BuildTasteQuestions(modelBuilder);
        BuildTasteEvaluations(modelBuilder);
        BuildTasteEvaluationQuestions(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var deletedAtProperty = entityType.FindProperty("DeletedAt");
            if (deletedAtProperty != null && deletedAtProperty.ClrType == typeof(DateTimeOffset?))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "p");
                var body = Expression.Equal(
                    Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(DateTimeOffset?) }, parameter, Expression.Constant("DeletedAt")),
                    Expression.Constant(null));
                var lambda = Expression.Lambda(body, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }
}

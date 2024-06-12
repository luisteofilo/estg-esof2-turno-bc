using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext
    {
        private void BuildInteracao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interacao>(entity =>
            {
                entity.HasKey(e => new { e.user_id, e.vinho_id });

                entity.Property(e => e.user_id)
                    .IsRequired();

                entity.Property(e => e.vinho_id)
                    .IsRequired();

                entity.Property(e => e.tipo_vinho)
                    .IsRequired();

                entity.Property(e => e.tipo_interacao)
                    .IsRequired();

                // Configurando as chaves estrangeiras
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.user_id)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Vinho)
                    .WithMany()
                    .HasForeignKey(e => e.vinho_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
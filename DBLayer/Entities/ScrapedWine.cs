using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class ScrapedWine
{
   [Key]
   public Guid ScrapedWineId { get; set; }

   [Required]
   public string Url { get; set; }

   [Required]
   public string Label { get; set; }

   [Required]
   public DateTimeOffset CreatedAt { get; set; }
}

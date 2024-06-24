using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities
{
    public class Interaction
    {
        [Key]
        public Guid InteractionLinkId { get; set; } 
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public Guid WineId { get; set; }
        
        [Required]
        public int InteractionType { get; set; }

        // Navegação para as entidades relacionadas
        public User User { get; set; }
        public Wine Wine { get; set; }
    }
}
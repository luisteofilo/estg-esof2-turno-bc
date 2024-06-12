using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities
{
    public class Interacao
    {
        [Required]
        public Guid user_id { get; set; }
        
        [Required]
        public Guid vinho_id { get; set; }
        
        [Required]
        public int tipo_interacao { get; set; }

        // Navegação para as entidades relacionadas
        public User User { get; set; }
        public Vinho Vinho { get; set; }
    }
}
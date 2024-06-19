using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESOF.WebApp.DBLayer.Entities;

//Tabela para pedidos de amizade

public class FriendRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid SenderId { get; set; }
    
    [Required]
    public Guid ReceiverId { get; set; }

    [Required]
    public DateTime RequestDate { get; set; }

    public bool IsAccepted { get; set; }

    // Navigation properties
    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; }

    [ForeignKey(nameof(ReceiverId))]
    public User Receiver { get; set; }
}

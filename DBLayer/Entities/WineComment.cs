using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class WineComment
{
    [Key]
    public Guid WineCommentId { get; set; }
    [Required]
    public string Comment  { get; set; }
    [Required]
    public decimal Evaluation { get; set; }
}
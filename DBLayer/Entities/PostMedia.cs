using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class PostMedia
{
    [Key]
    public Guid MediaId { get; set; }
    
    [Required, ForeignKey("Post")]
    public Guid MediaPostId { get; set; }
    public Post MediaPost { get; set; }
    
    public string Filename { get; set; }
    public string FileExtension { get; set; }
    
    public byte[] Data { get; set; }
}
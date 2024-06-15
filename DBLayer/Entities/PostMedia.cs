using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class PostMedia
{
    [Key]
    public Guid MediaId { get; set; }
    
    public Guid MediaPostId { get; set; }
    [Required, ForeignKey(nameof(MediaPostId))]
    public Post Post { get; set; }
    
    public string Filename { get; set; }
    public string FileExtension { get; set; }
    
    public byte[] Data { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class PostMedia
{
    [Key]
    public Guid MediaId { get; set; }
    
    [Required]
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    
    public string Filename { get; set; }
    public string FileExtension { get; set; }
    
    public byte[] Data { get; set; }
}
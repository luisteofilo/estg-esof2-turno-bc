namespace ESOF.WebApp.DBLayer.Entities;
using System.ComponentModel.DataAnnotations;

public class Wine
{
    [Key]
    public Guid WineId { get; set; }
    
    public ICollection<WineComment> WineComments { get; set; }
    
    public Wine()
    {
        WineComments = new List<WineComment>();
    }
}
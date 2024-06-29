namespace ESOF.WebApp.DBLayer.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class ParticipantWine
{
    [Key]
    public Guid ParticipantWineId { get; set; }
    
    [Required]
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
    
    [Required]
    public Guid WineId { get; set; }
    public Wine Wine { get; set; }
    
    [Required]
    public Guid BlindEventId { get; set; }
    public BlindEvent BlindEvent { get; set; }

    
}
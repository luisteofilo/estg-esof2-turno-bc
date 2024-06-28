namespace ESOF.WebApp.DBLayer.Entities;

using System;
using System.ComponentModel.DataAnnotations; 

public class BlindEvent
{
    [Key]
    public Guid BlindEventId { get; set; }
    [Required]
    public Guid OrganizerId { get; set; } 
    public User Organizer { get; set; }
    [Required]
    public DateTime EventDate { get; set; }
    [Required]
    public string Name { get; set; }
    
    public ICollection<Participant> Participants { get; set; }
    public ICollection<Evaluation> Evaluations { get; set; }
    public ICollection<ParticipantWine> ParticipantWines { get; set; }

    public BlindEvent()
    {
        Participants = new List<Participant>();
        Evaluations = new List<Evaluation>();
        ParticipantWines = new List<ParticipantWine>();
    }
}
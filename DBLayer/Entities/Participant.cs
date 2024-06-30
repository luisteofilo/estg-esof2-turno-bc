namespace ESOF.WebApp.DBLayer.Entities;

using System;
using System.ComponentModel.DataAnnotations; 

public class Participant
{
    [Key]
    public Guid ParticipantId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; }
    [Required]
    public Guid BlindEventId { get; set; }
    public BlindEvent BlindEvent { get; set; }
    public ICollection<Evaluation> Evaluations { get; set; }
    public ICollection<ParticipantWine> ParticipantWines { get; set; }


    public Participant()
    {
        Evaluations = new List<Evaluation>();
        ParticipantWines = new List<ParticipantWine>();
    }

}
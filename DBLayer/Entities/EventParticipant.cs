using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class EventParticipant
{
    [Key]
    public Guid EventParticipantId { get; set; }

    [Required]
    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }

    [Required]
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }
}
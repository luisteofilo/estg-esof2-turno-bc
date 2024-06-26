﻿using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Event
{
    [Key]
    public Guid EventId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string Slug { get; set; }

    // Navigation property for associated EventParticipants
    public ICollection<EventParticipant> EventParticipants { get; set; }
}
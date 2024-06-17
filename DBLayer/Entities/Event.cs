// DBLayer/Entities/Event.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        public bool BlindTasting { get; set; }
        
        public ICollection<Wine> Wines { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
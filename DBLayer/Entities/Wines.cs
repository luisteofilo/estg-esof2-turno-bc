using System;
using System.Collections.Generic;

namespace ESOF.WebApp.DBLayer.Entities
{
    public class Wine
    {
        public Guid WineId { get; set; }
        public string Name { get; set; }
        public Guid? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid? RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<WineGrapeTypeLink> WineGrapeTypeLinks { get; set; }
    }
}
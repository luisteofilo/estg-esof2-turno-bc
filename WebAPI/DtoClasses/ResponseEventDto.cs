namespace WebAPI.DtoClasses
{
    public class ResponseEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        
        public string Description { get; set; }
        
        public bool BlindTasting { get; set; } 
        
        public string WineType { get; set; }
        
    }
    
    
}
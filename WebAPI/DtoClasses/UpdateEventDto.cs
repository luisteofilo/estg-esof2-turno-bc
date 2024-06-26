namespace WebAPI.DtoClasses
{
    public class UpdateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool BlindTasting { get; set; }
        public string WineType { get; set; }
        
        public string Slug { get; set; }

    }
}

namespace Frontend.DtoClasses
{
    public class TasteQuestionAnswerDto
    {
        public Guid TasteQuestionId { get; set; }
        public string? Answer { get; set; }
        public bool AnswerBool { get; set; }
    }

}
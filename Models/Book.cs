namespace simulacro1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Pages { get; set; }
        public string? Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Description { get; set; }
    }
}
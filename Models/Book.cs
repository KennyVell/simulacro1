namespace simulacro1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string? Title { get; set; }
        public required int Pages { get; set; }
        public required string? Language { get; set; }
        public required DateTime PublicationDate { get; set; }
        public required string? Description { get; set; }
        public required string? Status { get; set; } // "active" or "inactive"
        
        public required int AuthorId { get; set; }
        public Author? Author { get; set; }
        
        public required int EditorialId { get; set; }
        public Editorial? Editorial { get; set; }
    }
}
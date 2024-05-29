namespace simulacro1.DTOs.Books
{
    public class BookDTO
    {      
        public string? Title { get; set; }
        public int Pages { get; set; }
        public string? Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int AuthorId { get; set; }        
        public int EditorialId { get; set; }
    }
}
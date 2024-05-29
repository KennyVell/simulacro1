namespace simulacro1.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }        
        public string? Title { get; set; }
        public int Pages { get; set; }
        public string? Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Description { get; set; }
        public string? Estado { get; set; }
        
        public int AuthorId { get; set; }        
        public int EditorialId { get; set; }
    }
}
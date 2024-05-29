using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Author
    {
        public required int Id { get; set; }
        public required string? Name { get; set; }
        public required string? LastName { get; set; }
        public required string? Email { get; set; }
        public required string? Nationality { get; set; }
        public required string? Status { get; set; } // "active" or "inactive"

        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
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
        public string? Estado { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Address { get; set; }
        public required string? Phone { get; set; }
        public required string? Email { get; set; }
        public required string? Status { get; set; } // "active" or "inactive"
        
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
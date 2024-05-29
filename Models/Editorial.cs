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
        public string? Estado { get; set; }
        
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
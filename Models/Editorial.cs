using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
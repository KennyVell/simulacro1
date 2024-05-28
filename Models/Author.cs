using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
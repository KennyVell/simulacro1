using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace simulacro1.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
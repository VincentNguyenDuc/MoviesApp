using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Producer
{
    [Key]
    public int Id { get; set; }
    public string? ProfilePictureURL { get; set; }
    [Required]
    public string? FullName { get; set; }
    [MaxLength(1000)]
    public string? Bio { get; set; }

    // Relationships
    public List<Movie>? Movies { get; set; }
}

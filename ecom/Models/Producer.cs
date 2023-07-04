using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Producer
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Picture")]
    public string? ProfilePictureURL { get; set; }

    [Display(Name = "Full Name")]
    [Required]
    public string? FullName { get; set; }
    
    [MaxLength(1000)]
    [Display(Name = "Biography")]
    public string? Bio { get; set; }

    // Relationships
    public List<Movie>? Movies { get; set; }
}

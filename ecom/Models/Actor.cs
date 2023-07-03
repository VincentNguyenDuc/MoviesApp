using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }
    public string? ProfilePictureURL { get; set; }
    [Required]
    [MaxLength(100)]
    public string? FullName { get; set; }
    [MaxLength(1000)]
    public string? Bio { get; set; }
    public List<Actor_Movie>? Actors_Movies { get; set; }
}

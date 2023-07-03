using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ecom.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Profile Picture URL")]
    public string? ProfilePictureURL { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Full Name")]
    public string? FullName { get; set; }

    [MaxLength(1000)]
    [Display(Name = "Biography")]
    public string? Bio { get; set; }
    public List<Actor_Movie>? Actors_Movies { get; set; }
}

using System.ComponentModel.DataAnnotations;
using ecom.Services.Base;

namespace ecom.Models;

public class Actor:IEntityBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is required")]
    public string? ProfilePictureURL { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
    public string? FullName { get; set; }

    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "String length must be between 10 and 1000 characters")]
    public string? Bio { get; set; }

    // Relationships
    public virtual List<Actor_Movie>? Actors_Movies { get; set; }
}

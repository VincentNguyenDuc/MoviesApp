using System.ComponentModel.DataAnnotations;
using ecom.Services.Base;

namespace ecom.Models;

public class Cinema : IEntityBaseModel
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Logo is required")]
    public string? Logo { get; set; }

    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    public string? Name { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters")]
    public string? Description { get; set; }

    // Relationships
    public virtual List<Movie> Movies { get; set; }
}

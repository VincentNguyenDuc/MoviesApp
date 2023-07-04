using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Cinema
{
    [Key]
    public int Id {get; set;}

    [Display(Name = "Cinema Logo")]
    public string? Logo { get; set; }

    [Display(Name = "Cinema Name")]
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Display(Name = "Description")]
    [MaxLength(1000)]
    public string? Description { get; set; }
    public List<Movie>? Movies{ get; set; }
}

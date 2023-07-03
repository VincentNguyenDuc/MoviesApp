using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Cinema
{
    [Key]
    public int Id {get; set;}
    public string? Logo { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(1000)]
    public string? Description { get; set; }
    public List<Movie>? Movies{ get; set; }
}

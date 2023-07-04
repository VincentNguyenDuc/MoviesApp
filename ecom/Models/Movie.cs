﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ecom.Data.Enums;

namespace ecom.Models;

public class Movie
{
    [Key]
    public int Id { get; set;}
    [Required]
    [MaxLength(100)]
    public string? Name { get; set;}
    [MaxLength(1000)]
    public string? Description { get; set;}

    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public double Price { get; set;}    
    public string? ImageURL { get; set;}
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public MovieCategory MovieCategory { get; set;}

    // Relationships
    public List<Actor_Movie>? Actors_Movies { get; set;}

    // Cinema
    public int CinemaId { get; set;}
    [ForeignKey("CinemaId")]
    public Cinema? Cinema { get; set;}

    // Producer
    public int ProducerId { get; set; }
    [ForeignKey("ProducerId")]
    public Producer? Producer { get; set; }
}

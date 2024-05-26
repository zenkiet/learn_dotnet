using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Entities;

public class Game
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }
    
    [Range(1, 100)]
    public required decimal Price { get; set; }
    
    [Url]
    [StringLength(255)]
    public string? ImageUri { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
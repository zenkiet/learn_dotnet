using System.ComponentModel.DataAnnotations;

namespace GameStore.API;

public record GameDto(int Id, string Name, string Genre, decimal Price, string? ImageUri, DateTime CreatedAt, DateTime UpdatedAt);

public record CreateGameDto(
    [Required]
    [StringLength(50)]
    string Name,
    
    [Required]
    [StringLength(20)]
    string Genre,
    
    [Range(1, 100)]
    decimal Price,
    
    [Url]
    string? ImageUri
);

public record UpdateGameDto(
    [Required]
    [StringLength(50)]
    string Name,
    
    [Required]
    [StringLength(20)]
    string Genre,
    
    [Range(1, 100)]
    decimal Price,
    
    [Url]
    string? ImageUri
);
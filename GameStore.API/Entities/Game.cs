namespace GameStore.API.Entities;
public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Genre { get; set; }
    public required decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTIme.Now;
}
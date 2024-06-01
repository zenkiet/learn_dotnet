using GameStore.API.Entities;

namespace GameStore.API.Repositories;

public class GamesRepository : IGamesRepository
{
    private static readonly List<Game> Games =
    [
        new Game()
        {
            Id = 1,
            Name = "The Legend of Zelda: Breath of the Wild",
            Genre = "Action-adventure",
            Price = 59.99m,
            ImageUri = "https://placeholder.co/300",
        },


        new Game()
        {
            Id = 2,
            Name = "Super Mario Odyssey",
            Genre = "Platformer",
            Price = 59.99m,
            ImageUri = "https://placeholder.co/300",
        },


        new Game()
        {
            Id = 3,
            Name = "Mario Kart 8 Deluxe",
            Genre = "Racing",
            Price = 59.99m,
            ImageUri = "https://placeholder.co/300",
        },


        new Game()
        {
            Id = 4,
            Name = "Splatoon 2",
            Genre = "Shooter",
            Price = 59.99m,
            ImageUri = "https://placeholder.co/300",
        }
    ];


    public IEnumerable<Game> GetAll() => Games;
    
    public Game? Get(int id) => Games.FirstOrDefault(g => g.Id == id);

    public void Add(Game game)
    {
        game.Id = Games.Max(g => g.Id) + 1;
        Games.Add(game);
    }
    
    public void Update(Game updatedGame)
    {
        var index = Games.FindIndex(g => g.Id == updatedGame.Id);
        if (index == -1)
        {
            return;
        }
        Games[index] = updatedGame;
    }
    
    public void Delete(int id)
    {
        var game = Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return;
        }
        Games.Remove(game);
    }
}
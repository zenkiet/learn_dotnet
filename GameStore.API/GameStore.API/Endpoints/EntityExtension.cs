using GameStore.API.Entities;

namespace GameStore.API.Endpoints;

public static class EntityExtension
{
    public static GameDto AsDto(this Game game) => new GameDto(game.Id, game.Name, game.Genre, game.Price, game.ImageUri, game.CreatedAt, game.UpdatedAt);
}
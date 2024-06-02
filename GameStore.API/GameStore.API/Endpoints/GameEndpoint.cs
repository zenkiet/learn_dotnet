using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints;

public static class GameEndpoint
{
     
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gameGroup = routes.MapGroup("/games").WithParameterValidation();    

        gameGroup.MapGet("/", (IGamesRepository repository) => 
                repository.GetAll().Select(game => game.AsDto())).WithName("GetGames").WithOpenApi();

        gameGroup.MapGet("/{id}", (IGamesRepository repository,int id) =>
        {
            var game = repository.Get(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        }).WithName("GetGameById").WithOpenApi();

        gameGroup.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            var game = new Game
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ImageUri = gameDto.ImageUri
            };
            
            repository.Add(game);
            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
        }).WithName("CreateGame").WithOpenApi();

        gameGroup.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto gameDto) =>
        {
            var existingGame = repository.Get(id);
            
            if (existingGame is null) return Results.NotFound();
            
            existingGame.Name = gameDto.Name;
            existingGame.Genre = gameDto.Genre;
            existingGame.Price = gameDto.Price;
            existingGame.ImageUri = gameDto.ImageUri;
            existingGame.UpdatedAt = DateTime.Now;
            
            repository.Update(existingGame);
            return Results.NoContent();

        }).WithName("UpdateGame").WithOpenApi();

        gameGroup.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            var existingGame = repository.Get(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }
            
            repository.Delete(id);  
            return Results.NoContent();
        }).WithName("DeleteGame").WithOpenApi();

        return gameGroup;
    }
}
using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints;

public static class GameEndpoint
{
     
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gameGroup = routes.MapGroup("/games").WithParameterValidation();    

        gameGroup.MapGet("/", (IGamesRepository repository) => repository.GetAll())
            .WithName("GetGames").WithOpenApi();

        gameGroup.MapGet("/{id}", (IGamesRepository repository,int id) =>
        {
            var game = repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName("GetGameById").WithOpenApi();

        gameGroup.MapPost("/", (IGamesRepository repository, Game game) =>
        {
            repository.Add(game);
            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
        }).WithName("CreateGame").WithOpenApi();

        gameGroup.MapPut("/{id}", (IGamesRepository repository, int id, Game game) =>
        {
            var existingGame = repository.Get(id);
            
            if (existingGame is null) return Results.NotFound();
            
            repository.Update(game);
            return Results.NoContent();

        }).WithName("UpdateGame").WithOpenApi();

        gameGroup.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            var existingGame = repository.Get(id);

            if (existingGame is not null)
            {
                repository.Delete(id);  
                return Results.NoContent();
            }
            return Results.NotFound();
        }).WithName("DeleteGame").WithOpenApi();

        return gameGroup;
    }
}
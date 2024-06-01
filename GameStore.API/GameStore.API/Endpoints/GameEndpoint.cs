using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints;

public static class GameEndpoint
{
    private static readonly InMemGamesRepository Repository = new InMemGamesRepository();
     
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gameGroup = routes.MapGroup("/games").WithParameterValidation();    

        gameGroup.MapGet("/", () => Repository.GetAll())
            .WithName("GetGames").WithOpenApi();

        gameGroup.MapGet("/{id}", (int id) =>
        {
            var game = Repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName("GetGameById").WithOpenApi();

        gameGroup.MapPost("/", (Game game) =>
        {
            Repository.Add(game);
            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
        }).WithName("CreateGame").WithOpenApi();

        gameGroup.MapPut("/{id}", (int id, Game game) =>
        {
            var existingGame = Repository.Get(id);
            
            if (existingGame is null) return Results.NotFound();
            
            Repository.Update(game);
            return Results.NoContent();

        }).WithName("UpdateGame").WithOpenApi();

        gameGroup.MapDelete("/{id}", (int id) =>
        {
            var existingGame = Repository.Get(id);

            if (existingGame is not null)
            {
                Repository.Delete(id);  
                return Results.NoContent();
            }
            return Results.NotFound();
        }).WithName("DeleteGame").WithOpenApi();

        return gameGroup;
    }
}
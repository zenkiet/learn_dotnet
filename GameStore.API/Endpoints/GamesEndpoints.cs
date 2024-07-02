
using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            InMemGameRepository repository = new();

            var group = routes.MapGroup("/games")
               .WithParameterValidation();

            group.MapGet("/", (IInMemGameRepository repository) => repository.GetAll());

            group.MapGet("/{id}", (IInMemGameRepository repository, int id) =>
            {
                Game? game = repository.Get(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();

            }).WithName("GetGameEndpointName");

            group.MapPost("/", (IInMemGameRepository repository, Game game) =>
            {
                repository.Create(game);

                return Results.CreatedAtRoute("GetGameEndpointName", new
                {
                    id = game.Id
                }, game);
            });

            group.MapPut("/{id}", (IInMemGameRepository repository, int id, Game game) =>
            {
                var existingGame = repository.Get(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = game.Name;
                existingGame.Genre = game.Genre;
                existingGame.Price = game.Price;
                existingGame.ImageUri = game.ImageUri;
                existingGame.UpdatedAt = DateTime.Now;

                repository.Update(existingGame);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", (IInMemGameRepository repository, int id) =>
            {
                Game? game = repository.Get(id);

                if (game is null)
                {
                    return Results.NotFound();
                }

                repository.Delete(id);

                return Results.NoContent();

            }).WithName("DeleteGame");

            return group;
        }
    }
}

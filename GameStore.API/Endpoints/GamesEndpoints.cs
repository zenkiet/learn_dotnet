
using GameStore.API.Entities;

namespace GameStore.API.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

        static List<Game> games =
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
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/games")
               .WithParameterValidation();
            group.MapGet("/", () => games);

            group.MapGet("/{id}", (int id) => games.FirstOrDefault(g => g.Id == id)).WithName("GetGameById");

            group.MapPost("/", (Game game) =>
            {
                game.Id = games.Max(g => g.Id) + 1;
                games.Add(game);
                return Results.CreatedAtRoute("GetGameById", new
                {
                    id = game.Id
                }, game);
            }).WithName("CreateGame");

            group.MapPut("/{id}", (int id, Game game) =>
            {
                var existingGame = games.FirstOrDefault((game) => game.Id == id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = game.Name;
                existingGame.Genre = game.Genre;
                existingGame.Price = game.Price;
                existingGame.ImageUri = game.ImageUri;
                existingGame.UpdatedAt = DateTime.Now;
                return Results.NoContent();
            }).WithName("UpdateGame");

            group.MapDelete("/{id}", (int id) =>
            {
                var ExistingGame = games.FirstOrDefault((game) => game.Id == id);

                if (ExistingGame is null)
                {
                    return Results.NotFound();
                }

                games.Remove(ExistingGame);

                return Results.NoContent();

            }).WithName("DeleteGame");

            return group;
        }
    }
}

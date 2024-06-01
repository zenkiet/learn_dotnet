using GameStore.API.Entities;

namespace GameStore.API.Repositories;

public interface IGamesRepository
{
    IEnumerable<Game> GetAll();
    Game? Get(int id);
    void Add(Game game);
    void Update(Game updatedGame);
    void Delete(int id);
}
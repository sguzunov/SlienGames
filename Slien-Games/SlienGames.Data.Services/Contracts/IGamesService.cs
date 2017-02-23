using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGamesService
    {
        IEnumerable<GameDetails> GetAllGames();

        GameDetails GetAGameById(object id);

        GameDetails GetDetailsWithCommentsByName(string gameName);

        bool LikeGame(int gameId, string username);
    }
}

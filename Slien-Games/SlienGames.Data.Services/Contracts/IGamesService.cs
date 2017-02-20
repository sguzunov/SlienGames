using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGamesService
    {
        IEnumerable<EmbeddedGame> GetAll();

        EmbeddedGame GetById(object id);

        GameDetails GetDetailsWithComments(string gameName);
    }
}

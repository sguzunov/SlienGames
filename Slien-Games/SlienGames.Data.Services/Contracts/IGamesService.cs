using System;
using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGamesService
    {
        IEnumerable<GameDetails> GetAll();

        GameDetails GetById(object id);

        GameDetails GetDetailsWithComments(string gameName);

        void RateGame(int gameId, Guid userId, int ratingValue);
    }
}

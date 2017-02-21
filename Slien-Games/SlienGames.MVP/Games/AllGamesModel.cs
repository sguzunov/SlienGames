using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.MVP.Games
{
    public class AllGamesModel
    {
        public IEnumerable<GameDetails> Games { get; set; }
    }
}
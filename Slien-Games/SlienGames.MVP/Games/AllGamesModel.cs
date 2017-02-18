using SlienGames.Data.Models;
using System.Collections.Generic;

namespace SlienGames.MVP.Games
{
    public class AllGamesModel
    {
        public IEnumerable<EmbeddedGame> EmbeddedGames { get; set; }
    }
}
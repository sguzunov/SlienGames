using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.MVP.Games.Details
{
    public class GameDetailsViewModel
    {
        public string GameName { get; set; }

        public string CoverImageFileSystemPath { get; set; }

        public string GameDescription { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
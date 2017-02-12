using System.Collections.Generic;
using SlienGames.Data.Models;

namespace SlienGames.Web.Models
{
    public class GameInfoModel
    {
        public string GameName { get; set; }

        public string CoverImageFileSystemPath { get; set; }

        public string GameDescription { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
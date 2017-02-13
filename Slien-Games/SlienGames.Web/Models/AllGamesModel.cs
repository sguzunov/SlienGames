using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlienGames.Web.Models
{
    public class AllGamesModel
    {
        public IEnumerable<EmbeddedGame> EmbeddedGames { get; set; }
    }
}
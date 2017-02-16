using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlienGames.Web.Models
{
    public class PlayedGameModel
    {
        public EmbeddedGame EmbeddedGame { get; set; }

        public User User { get; set; }
    }
}
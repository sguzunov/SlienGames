using SlienGames.Data.Models;

namespace SlienGames.MVP.PlayedGame.CurrentGame
{
    public class CurrentGameModel
    {
        public EmbeddedGame EmbeddedGame { get; set; }

        public User User { get; set; }
    }
}
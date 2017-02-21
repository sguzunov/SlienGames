using System;

namespace SlienGames.MVP.Games.Details
{
    public class RateGameEventArgs
    {
        public RateGameEventArgs(int gameId, Guid userId, int rating)
        {
            this.GameId = gameId;
            this.UserId = userId;
            this.Rating = rating;
        }

        public int GameId { get; set; }

        public Guid UserId { get; set; }

        public int Rating { get; set; }
    }
}

namespace SlienGames.MVP.Games.Details
{
    public class LikeGameEventArgs
    {
        public LikeGameEventArgs(int gameId, string username)
        {
            this.GameId = gameId;
            this.Username = username;
        }

        public int GameId { get; set; }

        public string Username { get; set; }
    }
}

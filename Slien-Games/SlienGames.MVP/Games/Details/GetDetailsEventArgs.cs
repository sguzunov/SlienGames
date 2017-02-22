namespace SlienGames.MVP.Games.Details
{
    public class GetDetailsEventArgs
    {
        public GetDetailsEventArgs(string gameName, string username)
        {
            this.GameName = gameName;
            this.Username = username;
        }

        public string GameName { get; private set; }

        public string Username { get; set; }
    }
}
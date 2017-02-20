namespace SlienGames.MVP.Games.Details
{
    public class GetGameDetailsEventArgs
    {
        public GetGameDetailsEventArgs(string gameName)
        {
            this.GameName = gameName;
        }

        public string GameName { get; private set; }
    }
}
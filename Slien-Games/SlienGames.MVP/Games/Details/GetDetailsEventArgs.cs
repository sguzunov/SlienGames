namespace SlienGames.MVP.Games.Details
{
    public class GetDetailsEventArgs
    {
        public GetDetailsEventArgs(string gameName)
        {
            this.GameName = gameName;
        }

        public string GameName { get; private set; }
    }
}
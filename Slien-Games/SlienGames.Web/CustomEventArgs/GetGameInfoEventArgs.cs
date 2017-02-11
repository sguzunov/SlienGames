namespace SlienGames.Web.CustomEventArgs
{
    public class GetGameInfoEventArgs
    {
        public GetGameInfoEventArgs(string gameName)
        {
            this.GameName = gameName;
        }

        public string GameName { get; private set; }
    }
}
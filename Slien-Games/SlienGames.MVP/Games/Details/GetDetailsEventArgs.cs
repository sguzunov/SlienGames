using System;

namespace SlienGames.MVP.Games.Details
{
    public class GetDetailsEventArgs
    {
        public GetDetailsEventArgs(string gameName, string username)
        {
            if (gameName == null)
            {
                throw new ArgumentNullException(nameof(gameName));
            }

            this.GameName = gameName;
            this.Username = username;
        }

        public string GameName { get; private set; }

        public string Username { get; set; }
    }
}
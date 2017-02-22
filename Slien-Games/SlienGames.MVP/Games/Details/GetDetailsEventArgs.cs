using System;

namespace SlienGames.MVP.Games.Details
{
    public class GetDetailsEventArgs
    {
        public GetDetailsEventArgs(string gameName)
        {
            if (gameName == null)
            {
                throw new ArgumentNullException(nameof(gameName));
            }

            this.GameName = gameName;
        }

        public string GameName { get; private set; }
    }
}
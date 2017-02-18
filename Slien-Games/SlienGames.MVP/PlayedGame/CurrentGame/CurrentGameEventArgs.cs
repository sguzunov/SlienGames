using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.MVP.PlayedGame.CurrentGame
{
    public class CurrentGameEventArgs
    {
        public CurrentGameEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}

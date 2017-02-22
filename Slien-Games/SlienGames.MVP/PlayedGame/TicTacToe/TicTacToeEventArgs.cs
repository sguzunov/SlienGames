using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.MVP.PlayedGame.TicTacToe
{
    public class TicTacToeEventArgs : EventArgs
    {

        public TicTacToeEventArgs(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.Id = id;
        }
        public object Id { get; private set; }
    }
}

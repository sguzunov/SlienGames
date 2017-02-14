using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SlienGames.Web.GamesHubs
{
    public class TicTacToeHub : Hub
    {
        public void FindOpponent(string data)
        {
            int a = 9;
        }
    }
}
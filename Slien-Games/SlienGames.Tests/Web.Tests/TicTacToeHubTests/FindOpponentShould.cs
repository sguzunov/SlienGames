using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using SlienGames.Web.GamesHubs.States;
using TicTacToeGame.Factories;
using Microsoft.AspNet.SignalR.Hubs;
using SlienGames.Web.GamesHubs;
using TicTacToeGame.Contracts;

namespace SlienGames.Tests.Web.Tests.TicTacToeHubTests
{
    internal interface IClientContract
    {
        void noOpponentFound();
    }

    [TestFixture]
    public class FindOpponentShould
    {
        [Test]
        public void CallClientNoOpponentFound()
        {
            // TODO:
        }
    }
}

using NUnit.Framework;
using SlienGames.MVP.PlayedGame.CurrentGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.PlayedGame.CurrentGame.CurrentGameEventargsTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void ThrowWhenIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CurrentGameEventArgs(null));
        }
    }
}

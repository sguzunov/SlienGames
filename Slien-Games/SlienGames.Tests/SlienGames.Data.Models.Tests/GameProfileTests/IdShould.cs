using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameProfileTests
{
    [TestFixture]
    public  class IdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var gameProfile = new GameProfile();
            gameProfile.Id = 1;

            var result = gameProfile.Id.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var gameProfile = new GameProfile();

            gameProfile.Id = 1;

            Assert.True(gameProfile.Id == 1);
        }
    }
}

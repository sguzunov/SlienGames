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
    public class RatingShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var gameProfile = new GameProfile();
            gameProfile.Rating = 1;

            var result = gameProfile.Rating.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var gameProfile = new GameProfile();

            gameProfile.Rating = 1;

            Assert.True(gameProfile.Rating == 1);
        }
    }
}

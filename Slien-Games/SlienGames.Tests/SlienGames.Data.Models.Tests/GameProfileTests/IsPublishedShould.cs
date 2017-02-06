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
    public class IsPublishedShould
    {

        [Test]
        public void Be_TypeOfBool()
        {
            var gameProfile = new GameProfile();
            gameProfile.IsPublished = true;

            var result = gameProfile.IsPublished.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var gameProfile = new GameProfile();

            gameProfile.IsPublished = true;

            Assert.True(gameProfile.IsPublished);
        }
    }
}

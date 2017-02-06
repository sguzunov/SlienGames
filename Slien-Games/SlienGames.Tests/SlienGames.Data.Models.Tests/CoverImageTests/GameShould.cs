using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CoverImageTests
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void Be_TypeOfIdentityUser()
        {
            var coverImage = new CoverImage();
            var gameProfile = new GameProfile();
            coverImage.Game = gameProfile;

            var result = coverImage.Game.GetType();

            Assert.True(result == typeof(GameProfile));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var coverImage = new CoverImage();
            var gameProfile = new GameProfile();

            coverImage.Game = gameProfile;

            Assert.True(coverImage.Game == gameProfile);
        }
    }
}

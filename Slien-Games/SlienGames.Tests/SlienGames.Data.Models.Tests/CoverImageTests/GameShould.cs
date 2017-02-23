using NUnit.Framework;
using SlienGames.Data.Models;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CoverImageTests
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void Be_TypeOfGameProfile()
        {
            var coverImage = new CoverImage();
            var gameProfile = new GameDetails();
            coverImage.Game = gameProfile;

            var result = coverImage.Game.GetType();

            Assert.True(result == typeof(GameDetails));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var coverImage = new CoverImage();
            var gameProfile = new GameDetails();

            coverImage.Game = gameProfile;

            Assert.True(coverImage.Game == gameProfile);
        }
    }
}

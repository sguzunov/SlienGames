using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class CoverImageShould
    {
        [Test]
        public void Be_TypeOfCoverImage()
        {
            var gameProfile = new GameDetails();
            var coverImage = new CoverImage();
            gameProfile.CoverImage = coverImage;

            var result = gameProfile.CoverImage.GetType();

            Assert.True(result == typeof(CoverImage));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var gameProfile = new GameDetails();
            var coverImage = new CoverImage();

            gameProfile.CoverImage = coverImage;

            Assert.True(gameProfile.CoverImage == coverImage);
        }
    }
}

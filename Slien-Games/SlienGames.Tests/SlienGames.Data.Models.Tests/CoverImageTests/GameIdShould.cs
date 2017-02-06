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
    public class GameIdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var coverImage = new CoverImage();
            coverImage.GameId = 1;

            var result = coverImage.GameId.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var coverImage = new CoverImage();

            coverImage.GameId = 1;

            Assert.True(coverImage.GameId == 1);
        }
    }
}

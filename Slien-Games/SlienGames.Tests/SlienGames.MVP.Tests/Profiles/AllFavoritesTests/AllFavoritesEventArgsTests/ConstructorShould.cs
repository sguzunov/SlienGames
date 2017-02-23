using NUnit.Framework;
using SlienGames.MVP.Profiles.AllFavorites;
using System;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Profiles.AllFavoritesTests.AllFavoritesEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AllFavoritesEventArgs(null));
        }
    }
}

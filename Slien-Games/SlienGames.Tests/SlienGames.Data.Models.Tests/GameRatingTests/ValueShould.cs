using NUnit.Framework;

using SlienGames.Data.Models;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.VoteTests
{
    [TestFixture]
    class ValueShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var vote = new GameRating();
            vote.Value = 1;

            var result = vote.Value.GetType();

            Assert.True(result == typeof(int));
        }
    }
}

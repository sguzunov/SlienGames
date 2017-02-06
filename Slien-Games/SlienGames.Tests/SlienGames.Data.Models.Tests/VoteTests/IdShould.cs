using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.VoteTests
{
    [TestFixture]
    public class IdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var vote = new GameProfile();
            vote.Id = 1;

            var result = vote.Id.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var vote = new Vote();

            vote.Id = 1;

            Assert.True(vote.Id == 1);
        }
    }
}

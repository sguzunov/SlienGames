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
    class ValueShould
    {
        [Test]
        public void Be_TypeOfBool()
        {
            var vote = new Vote();
            vote.Value = true;

            var result = vote.Value.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var vote = new Vote();
            vote.Value = true;

            Assert.True(vote.Value);
        }
    }
}

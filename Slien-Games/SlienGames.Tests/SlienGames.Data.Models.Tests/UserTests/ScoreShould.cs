using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class ScoreShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var user = new User();
            user.Score = 1;

            var result = user.Score.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var user = new User();

            user.Score = 1;

            Assert.True(user.Score == 1);
        }
    }
}

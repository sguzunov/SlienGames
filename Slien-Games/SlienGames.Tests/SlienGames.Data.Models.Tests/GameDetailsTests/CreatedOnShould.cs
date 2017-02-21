using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameDetailsTests
{
    [TestFixture]
    public class CreatedOnShould
    {
        [Test]
        public void Be_TypeOfDateTime()
        {
            var gameProfile = new GameDetails();
            var date = new DateTime();
            gameProfile.CreatedOn = date;

            var result = gameProfile.CreatedOn.GetType();

            Assert.True(result == typeof(DateTime));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var gameProfile = new GameDetails();
            var date = new DateTime();

            gameProfile.CreatedOn = date;

            Assert.True(gameProfile.CreatedOn == date);
        }
    }
}

using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public  class GameProfileShould
    {
        [Test]
        public void Be_TypeOfGameProfile()
        {
            var comment = new Comment();
            var gameProfile = new GameDetails();
            comment.GameDetails = gameProfile;

            var result = comment.GameDetails.GetType();

            Assert.True(result == typeof(GameDetails));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var comment = new Comment();
            var gameProfile = new GameDetails();

            comment.GameDetails = gameProfile;

            Assert.True(comment.GameDetails == gameProfile);
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("GameProfile")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);

        }
    }
}

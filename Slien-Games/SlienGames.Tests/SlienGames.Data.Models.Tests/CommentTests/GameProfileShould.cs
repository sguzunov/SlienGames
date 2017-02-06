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
        public void Be_TypeOfIdentityUser()
        {
            var comment = new Comment();
            var gameProfile = new GameProfile();
            comment.GameProfile = gameProfile;

            var result = comment.GameProfile.GetType();

            Assert.True(result == typeof(GameProfile));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var comment = new Comment();
            var gameProfile = new GameProfile();

            comment.GameProfile = gameProfile;

            Assert.True(comment.GameProfile == gameProfile);
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

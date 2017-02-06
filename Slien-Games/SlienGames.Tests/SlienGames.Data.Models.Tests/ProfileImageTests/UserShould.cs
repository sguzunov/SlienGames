using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.ProfileImageTests
{
    [TestFixture]
    public class UserShould
    {
        [Test]
        public void Be_TypeOfCoverImage()
        {
            var profileImage = new ProfileImage();
            var user = new User();
            profileImage.User = user;

            var result = profileImage.User.GetType();

            Assert.True(result == typeof(User));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var profileImage = new ProfileImage();
            var user = new User();

            profileImage.User = user;

            Assert.True(profileImage.User == user);
        }
    }
}

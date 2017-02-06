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
    public class ProfileImageShould
    {
        [Test]
        public void Be_TypeOfProfileImage()
        {
            var user = new User();
            var profileImage = new ProfileImage();
            user.ProfileImage = profileImage;

            var result = user.ProfileImage.GetType();

            Assert.True(result == typeof(ProfileImage));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var user = new User();
            var profileImage = new ProfileImage();

            user.ProfileImage = profileImage;

            Assert.True(user.ProfileImage == profileImage);
        }
    }
}

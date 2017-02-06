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
    public class UserIdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var profileImage = new ProfileImage();
            profileImage.UserId = 1;

            var result = profileImage.Id.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var profileImage = new ProfileImage();

            profileImage.UserId = 1;

            Assert.True(profileImage.UserId == 1);
        }
    }
}

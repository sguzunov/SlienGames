using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SlienGames.Data.Services;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;

namespace SlienGames.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class AddReviewShould
    {
        [TestCase("pdf")]
        [TestCase("docx")]
        [TestCase("cs")]
        [TestCase("js")]
        [TestCase("cpp")]
        public void ThrowArgumentException_WhenFileExtensionIsNotFromAllowedOnce(string coverImageExtension)
        {
            var service = new UserService(It.IsAny<IRepository<User>>(), It.IsAny<ISlienGamesData>());

            Assert.Throws<ArgumentException>(() => service.AddReview(It.IsAny<string>(), coverImageExtension, "C:\\", It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        //[Test]
        //public void GetUserByThePassedUserId()
        //{
        //    var fakeUserRepository = new Mock<IRepository<User>>();
        //    var fakeUoW = new Mock<ISlienGamesData>();
        //    var service = new UserService(fakeUserRepository.Object, fakeUoW.Object);
        //    var fakeUser = new Mock<User>();
        //    var fakeUsersReviews = new Mock<ICollection<Review>>();
        //    int userId = 1;

        //    fakeUser.Setup(x => x.Reviews).Returns(fakeUsersReviews.Object);
        //    fakeUserRepository.Setup(x => x.GetById(userId)).Returns(fakeUser.Object).Verifiable();

        //    service.AddReview(It.IsAny<string>(), ".png", "C:\\", It.IsAny<int>(), It.IsAny<string>(), "12=12", It.IsAny<string>());

        //    fakeUserRepository.Verify(x => x.GetById(userId));
        //}
    }
}

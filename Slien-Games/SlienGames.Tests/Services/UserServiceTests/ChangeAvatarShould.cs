using Moq;
using NUnit.Framework;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;
using System;

namespace SlienGames.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class ChangeAvatarShould
    {
        [TestCase("pdf")]
        [TestCase("docx")]
        [TestCase("cs")]
        [TestCase("js")]
        [TestCase("cpp")]
        public void ThrowArgumentException_WhenFileExtensionIsNotFromAllowedOnce(string fileExtesion)
        {
            var service = new UserService(It.IsAny<IRepository<User>>(), It.IsAny<ISlienGamesData>());

            Assert.Throws<ArgumentException>(() => service.ChangeAvatar(It.IsAny<string>(), fileExtesion, It.IsAny<string>(), It.IsAny<object>()));
        }

        [Test]
        public void GetUserByThePassedUserId()
        {
            var fakeUserRepository = new Mock<IRepository<User>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new UserService(fakeUserRepository.Object, fakeUoW.Object);
            var fakeUser = new Mock<User>();
            int userId = 1;

            fakeUser.Setup(x => x.ProfileImage).Returns(new Mock<ProfileImage>().Object);
            fakeUserRepository.Setup(x => x.GetById(userId)).Returns(fakeUser.Object).Verifiable();

            service.ChangeAvatar(It.IsAny<string>(), ".png", It.IsAny<string>(), userId: 1);

            fakeUserRepository.Verify(x => x.GetById(userId));
        }

        [Test]
        public void CallUsersRepositoryToUpdateUser_AndCommitTheChanges()
        {
            var fakeUserRepository = new Mock<IRepository<User>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new UserService(fakeUserRepository.Object, fakeUoW.Object);
            var fakeUser = new Mock<User>();

            fakeUoW.Setup(x => x.Commit()).Verifiable();
            fakeUser.Setup(x => x.ProfileImage).Returns(new Mock<ProfileImage>().Object);
            fakeUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(fakeUser.Object);
            fakeUserRepository.Setup(x => x.Update(fakeUser.Object)).Verifiable();

            service.ChangeAvatar(It.IsAny<string>(), ".png", It.IsAny<string>(), It.IsAny<int>());

            fakeUserRepository.Verify(x => x.Update(fakeUser.Object));
            fakeUoW.Verify(x => x.Commit());
        }
    }
}

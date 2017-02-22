using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Manage.ManageAvatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.ManageAvatarTests.ManageAvatarPresenterTests
{
    [TestFixture]
   public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserPresenterIsNull()
        {
            var mockedView = new Mock<IManageAvatarView>();

            Assert.Throws<ArgumentNullException>(() => new ManageAvatarPresenter(mockedView.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenFileSaverIsNull()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedUserPresenter = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new ManageAvatarPresenter(mockedView.Object, mockedUserPresenter.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>();

            var presenter = new ManageAvatarPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>();

            var presenter = new ManageAvatarPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IManageAvatarView>>());
        }

        [Test]
        public void CallUsersServiceGetByIdMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedModel = new Mock<ManageAvatarModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new ManageAvatarPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            mockedView.Raise(x => x.GetCurrentUser += null, null,new IdEventArgs(1));

            mockedUsersService.Verify(x => x.GetUserById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallFileSaversSaveMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedModel = new Mock<ManageAvatarModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new ManageAvatarPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            mockedView.Raise(x => 
            x.SetNewAvatar += null, null, new ManageAvatarEventArgs("gosho","pesho","stamat",new byte[1],1));

            mockedFileSaver.Verify(x => x.SaveFile(It.IsAny<string>(),It.IsAny<byte[]>()), Times.Once);
        }

        [Test]
        public void CallUsersServiceChangeAvatarMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IManageAvatarView>();
            var mockedModel = new Mock<ManageAvatarModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new ManageAvatarPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            mockedView.Raise(x =>
            x.SetNewAvatar += null, null, new ManageAvatarEventArgs("gosho", "pesho", "stamat", new byte[1], 1));

            mockedUsersService.Verify(x =>
            x.ChangeAvatar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

    }
}

using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.ManagePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenInstantiatingWithNull()
        {
            var mockedView = new Mock<IManageView>();

            Assert.Throws<ArgumentNullException>(() => new ManagePresenter(mockedView.Object, null));
        }


        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IManageView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new ManagePresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IManageView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new ManagePresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IManageView>>());
        }
        
        [Test]
        public void CallUsersServiceGetAllMethodOnce_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IManageView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedModel = new Mock<ManageModel>();
            var mockedUser = new Mock<User>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);

            var presenter = new ManagePresenter(mockedView.Object, mockedUsersService.Object);
            mockedView.Raise(x => x.GetCurrentUser += null, null, new ManageEventArgs(1));

            mockedUsersService.Verify(x => x.GetUserById(It.IsAny<object>()), Times.Once);
        }
    }
}

using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.PlayedGame.CurrentGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.PlayedGame.CurrentGame.CurrentGamePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenGameServiceIsNull()
        {
            var mockedView = new Mock<ICurrentGameView>();

            Assert.Throws<ArgumentNullException>(() => new CurrentGamePresenter(mockedView.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<ICurrentGameView>();
            var mockedGameService = new Mock<IGamesService>();

            Assert.Throws<ArgumentNullException>(() => new CurrentGamePresenter(mockedView.Object, mockedGameService.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<ICurrentGameView>();
            var mockedGameService = new Mock<IGamesService>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new CurrentGamePresenter(mockedView.Object, mockedGameService.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<ICurrentGameView>();
            var mockedGameService = new Mock<IGamesService>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new CurrentGamePresenter(mockedView.Object, mockedGameService.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<ICurrentGameView>>());
        }

        [Test]
        public void CallUsersServiceGetByIdMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<ICurrentGameView>();
            var mockedGameService = new Mock<IGamesService>();
            var mockedModel = new Mock<CurrentGameModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new CurrentGamePresenter(mockedView.Object, mockedGameService.Object, mockedUsersService.Object);

            mockedView.Raise(x => x.GetUser += null, null, new CurrentGameEventArgs(1));

            mockedUsersService.Verify(x => x.GetUserById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallGamesServiceGetByIdMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<ICurrentGameView>();
            var mockedGameService = new Mock<IGamesService>();
            var mockedModel = new Mock<CurrentGameModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new CurrentGamePresenter(mockedView.Object, mockedGameService.Object, mockedUsersService.Object);

            mockedView.Raise(x => x.GetGame += null, null, new CurrentGameEventArgs(1));

            mockedGameService.Verify(x => x.GetAGameById(It.IsAny<object>()), Times.Once);
        }
    }
}

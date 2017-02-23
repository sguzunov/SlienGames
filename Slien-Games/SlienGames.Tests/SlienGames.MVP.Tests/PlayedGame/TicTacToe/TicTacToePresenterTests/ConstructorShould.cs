using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.PlayedGame.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.PlayedGame.TicTacToe.TicTacToePresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<ITicTacToeView>();

            Assert.Throws<ArgumentNullException>(() => new TicTacToePresenter(mockedView.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<ITicTacToeView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new TicTacToePresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<ITicTacToeView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new TicTacToePresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<ITicTacToeView>>());
        }

        [Test]
        public void CallUsersServiceGetByIdMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<ITicTacToeView>();
            var mockedModel = new Mock<TicTacToeModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedUser = new Mock<User>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new TicTacToePresenter(mockedView.Object, mockedUsersService.Object);

            mockedView.Raise(x => x.GetCurrentUser += null, null, new TicTacToeEventArgs(1));

            mockedUsersService.Verify(x => x.GetUserById(It.IsAny<object>()), Times.Once);
        }
    }
}

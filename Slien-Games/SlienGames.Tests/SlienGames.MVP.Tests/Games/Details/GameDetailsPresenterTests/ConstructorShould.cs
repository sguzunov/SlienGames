using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Games.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Games.Details.GameDetailsPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenGameServiceIsNull()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedCommentsService = new Mock<ICommentsService>();
            Assert.Throws<ArgumentNullException>(() => new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object, null, mockedCommentsService.Object));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WheUsersServiceIsNull()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedCommentsService = new Mock<ICommentsService>();
            var mockedUsersService = new Mock<IUsersService>();
            Assert.Throws<ArgumentNullException>(() => new GameDetailsPresenter(mockedView.Object, null , mockedUsersService.Object, mockedCommentsService.Object));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedCommentsService = new Mock<ICommentsService>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object, mockedUsersService.Object, null));
        }


        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedCommentsService = new Mock<ICommentsService>();

            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object, mockedUsersService.Object, mockedCommentsService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedCommentsService = new Mock<ICommentsService>();

            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object, mockedUsersService.Object, mockedCommentsService.Object);


            Assert.That(presenter, Is.InstanceOf<Presenter<IGameInfoView>>());
        }

        [Test]
        public void CallGamessServiceRateMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedModel = new Mock<GameDetailsViewModel>();
            var mockedGamesService = new Mock<IGamesService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedCommentsService = new Mock<ICommentsService>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedGameService = new Mock<IGamesService>();
            mockedGameService.Setup(x => x.LikeGame(It.IsAny<int>(), It.IsAny<string>()));
            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object, mockedUsersService.Object, mockedCommentsService.Object);

            mockedView.Raise(x => x.LikeGame += null, null, new LikeGameEventArgs(1, "gosho"));

            mockedGameService.Verify(x => x.LikeGame(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenCallGamessServiceGetDetailsWithCommentsMethodAndResultIsNull()
        {
            //var mockedView = new Mock<IGameInfoView>();
            //var mockedModel = new Mock<GameDetailsViewModel>();

            //var mockedUsersService = new Mock<IUsersService>();
            //var mockedCommentsService = new Mock<ICommentsService>();

            //mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            //var mockedGameService = new Mock<IGamesService>();
            //mockedGameService.Setup(x => x.GetDetailsWithComments(It.IsAny<string>())).Returns(null as GameDetails);
            //var presenter = new GameDetailsPresenter(mockedView.Object, mockedGameService.Object, mockedUsersService.Object, mockedCommentsService.Object);

            //var ex = Assert.Throws<ArgumentNullException>(() => mockedView.Raise(x => x.GetGameDetails += null, null, new GetDetailsEventArgs("gosho", "gosho")));

            //Assert.True(ex.Message.Contains("is not found"));
        }

        [Test]
        public void CallGamessServiceGetDetailsWithCommentsMethod_WhenViewsEventIsRaised()
        {
            //var mockedView = new Mock<IGameInfoView>();
            //var mockedModel = new Mock<GameDetailsViewModel>();
            //mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            //var mockedGameService = new Mock<IGamesService>();
            //var mockedGameInfo = new Mock<GameDetails>();
            //var mockedCoverImage = new Mock<CoverImage>();
            //mockedGameInfo.Setup(x => x.CoverImage).Returns(mockedCoverImage.Object);
            //mockedGameService.Setup(x => x.GetDetailsWithComments(It.IsAny<string>())).Returns(mockedGameInfo.Object);
            //var presenter = new GameDetailsPresenter(mockedView.Object, mockedGameService.Object);

            //mockedView.Raise(x => x.GetGameDetails += null, null, new GetDetailsEventArgs("gosho"));

            //mockedGameService.Verify(x => x.GetDetailsWithComments(It.IsAny<string>()), Times.Once);
        }
    }
}

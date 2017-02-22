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
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<IGameInfoView>();

            Assert.Throws<ArgumentNullException>(() => new GameDetailsPresenter(mockedView.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();

            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedGamesService = new Mock<IGamesService>();


            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGamesService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IGameInfoView>>());
        }

        [Test]
        public void CallGamessServiceRateMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedModel = new Mock<GameDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedGameService = new Mock<IGamesService>();
            mockedGameService.Setup(x => x.RateGame(It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<int>())).Verifiable();
            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGameService.Object);

            mockedView.Raise(x => x.RateGame += null, null, new RateGameEventArgs(1, new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"), 2));


            mockedGameService.Verify(x => x.RateGame(It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenCallGamessServiceGetDetailsWithCommentsMethodAndResultIsNull()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedModel = new Mock<GameDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedGameService = new Mock<IGamesService>();
            mockedGameService.Setup(x => x.GetDetailsWithComments(It.IsAny<string>())).Returns(null as GameDetails);
            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGameService.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => mockedView.Raise(x => x.GetGameDetails += null, null, new GetDetailsEventArgs("gosho")));

            Assert.True(ex.Message.Contains("is not found"));
        }

        [Test]
        public void CallGamessServiceGetDetailsWithCommentsMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IGameInfoView>();
            var mockedModel = new Mock<GameDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedGameService = new Mock<IGamesService>();
            var mockedGameInfo = new Mock<GameDetails>();
            var mockedCoverImage = new Mock<CoverImage>();
            mockedGameInfo.Setup(x => x.CoverImage).Returns(mockedCoverImage.Object);
            mockedGameService.Setup(x => x.GetDetailsWithComments(It.IsAny<string>())).Returns(mockedGameInfo.Object);
            var presenter = new GameDetailsPresenter(mockedView.Object, mockedGameService.Object);

            mockedView.Raise(x => x.GetGameDetails += null, null, new GetDetailsEventArgs("gosho"));

            mockedGameService.Verify(x => x.GetDetailsWithComments(It.IsAny<string>()), Times.Once);
        }
    }
}

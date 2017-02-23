using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Games.AllGamesPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<IAllGamesView>();

            Assert.Throws<ArgumentNullException>(() => new AllGamesPresenter(mockedView.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IAllGamesView>();
            var mockedGamesService = new Mock<IGamesService>();

            var presenter = new AllGamesPresenter(mockedView.Object, mockedGamesService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IAllGamesView>();
            var mockedGamesService = new Mock<IGamesService>();

            var presenter = new AllGamesPresenter(mockedView.Object, mockedGamesService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IAllGamesView>>());
        }

        [Test]
        public void CallGamessServiceGetAllMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IAllGamesView>();
            var mockedModel = new Mock<AllGamesModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedGamesService = new Mock<IGamesService>();
            mockedGamesService.Setup(x => x.GetAll()).Returns(new List<GameDetails>());
            var presenter = new AllGamesPresenter(mockedView.Object, mockedGamesService.Object);

            mockedView.Raise(x => x.GetGames += null, null,null);

            mockedGamesService.Verify(x => x.GetAll(), Times.Once);
        }

    }
}

using NUnit.Framework;
using Moq;

using SlienGames.Data.Models;
using SlienGames.Data.Contracts;
using SlienGames.Data.Services;

namespace SlienGames.Tests.Services.GamesServiceTests
{
    [TestFixture]
    public class GetAllGamesShould
    {
        [Test]
        public void CallGameRepository_GetAllMethod()
        {
            var fakeGamesRepository = new Mock<IRepository<GameDetails>>();
            var service = new GamesService(
                fakeGamesRepository.Object,
                It.IsAny<IRepository<GameRating>>(),
                It.IsAny<IRepository<User>>(),
                It.IsAny<ISlienGamesData>());

            fakeGamesRepository.Setup(x => x.GetAll()).Verifiable();

            service.GetAllGames();

            fakeGamesRepository.Verify(x => x.GetAll());
        }
    }
}

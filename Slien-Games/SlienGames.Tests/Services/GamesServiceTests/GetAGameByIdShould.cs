using Moq;
using NUnit.Framework;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;

namespace SlienGames.Tests.Services.GamesServiceTests
{
    [TestFixture]
    public class GetAGameByIdShould
    {
        [Test]
        public void CallRepository_GetById_WithCorrectParameter()
        {
            var fakeGamesRepository = new Mock<IRepository<GameDetails>>();
            var service = new GamesService(
                fakeGamesRepository.Object,
                It.IsAny<IRepository<GameRating>>(),
                It.IsAny<IRepository<User>>(),
                It.IsAny<ISlienGamesData>());

            int gameId = 1;

            fakeGamesRepository.Setup(x => x.GetById(gameId)).Verifiable();

            service.GetAGameById(gameId);

            fakeGamesRepository.Verify(x => x.GetById(gameId));
        }
    }
}

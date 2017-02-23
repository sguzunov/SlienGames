using Moq;
using NUnit.Framework;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SlienGames.Tests.Services.GamesServiceTests
{
    [TestFixture]
    public class GetDetailsWithCommentsByNameShould
    {
        [Test]
        public void CallGameRepository_GetAllMethod_CorrectOverload()
        {
            var fakeGamesRepository = new Mock<IRepository<GameDetails>>();
            var service = new GamesService(
                fakeGamesRepository.Object,
                It.IsAny<IRepository<GameRating>>(),
                It.IsAny<IRepository<User>>(),
                It.IsAny<ISlienGamesData>());

            fakeGamesRepository.Setup(x => x.GetAll<GameDetails>(
                It.IsAny<Expression<Func<GameDetails, bool>>>(),
                It.IsAny<Expression<Func<GameDetails, GameDetails>>>(),
                new[] { It.IsAny<Expression<Func<GameDetails, object>>>() }))
                .Returns(new List<GameDetails>())
                .Verifiable();

            service.GetDetailsWithCommentsByName(It.IsAny<string>());

            fakeGamesRepository.Verify(x => x.GetAll(
                It.IsAny<Expression<Func<GameDetails, bool>>>(),
                It.IsAny<Expression<Func<GameDetails, GameDetails>>>(),
                new[] { It.IsAny<Expression<Func<GameDetails, object>>>() }));
        }

        [Test]
        public void ReturnTheObjectReturnedFromRepository()
        {
            var fakeGamesRepository = new Mock<IRepository<GameDetails>>();
            var service = new GamesService(
                fakeGamesRepository.Object,
                It.IsAny<IRepository<GameRating>>(),
                It.IsAny<IRepository<User>>(),
                It.IsAny<ISlienGamesData>());
            var fakeGame = new Mock<GameDetails>();

            fakeGamesRepository.Setup(x => x.GetAll<GameDetails>(
                It.IsAny<Expression<Func<GameDetails, bool>>>(),
                It.IsAny<Expression<Func<GameDetails, GameDetails>>>(),
                new[] { It.IsAny<Expression<Func<GameDetails, object>>>() }))
                .Returns(new List<GameDetails>() { fakeGame.Object });

            var actualGame = service.GetDetailsWithCommentsByName(It.IsAny<string>());

            Assert.AreEqual(fakeGame.Object, actualGame);
        }
    }
}

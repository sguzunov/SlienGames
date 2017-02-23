using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;
using System.Linq.Expressions;

namespace SlienGames.Tests.Services.GamesServiceTests
{
    [TestFixture]
    public class LikeGameShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedusernameIsNull()
        {
            var service = new GamesService(
                It.IsAny<IRepository<GameDetails>>(),
                It.IsAny<IRepository<GameRating>>(),
                It.IsAny<IRepository<User>>(),
                It.IsAny<ISlienGamesData>());

            Assert.Throws<ArgumentNullException>(() => service.LikeGame(1, username: null));
        }

        [Test]
        public void CallRepository_GetAll_CorrectOVerload()
        {
            var fakeUsersRepository = new Mock<IRepository<User>>();
            var fakeGameRespository = new Mock<IRepository<GameDetails>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new GamesService(
                fakeGameRespository.Object,
                It.IsAny<IRepository<GameRating>>(),
                fakeUsersRepository.Object,
                fakeUoW.Object);
            var fakeUser = new Mock<User>();

            fakeUser.Setup(x => x.Favorites).Returns(new List<GameDetails>());
            fakeUsersRepository.Setup(x => x.GetAll<User>(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, User>>>(),
                new[] { It.IsAny<Expression<Func<User, object>>>() }))
                .Returns(new List<User>() { fakeUser.Object })
                .Verifiable();

            service.LikeGame(1, "John");

            fakeUsersRepository.Verify();
        }

        [Test]
        public void ReturnFalse_WhenTheUserHasAlreadyLikedTheGame()
        {
            var fakeUsersRepository = new Mock<IRepository<User>>();
            var fakeGameRespository = new Mock<IRepository<GameDetails>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new GamesService(
                fakeGameRespository.Object,
                It.IsAny<IRepository<GameRating>>(),
                fakeUsersRepository.Object,
                fakeUoW.Object);
            var fakeUser = new Mock<User>();
            var fakeLikedGame = new Mock<GameDetails>();
            int gameId = 1;
            var fakeLikedGameObject = fakeLikedGame.Object;

            fakeLikedGameObject.Id = 1;
            fakeUser.Setup(x => x.Favorites).Returns(new List<GameDetails>() { fakeLikedGameObject });
            fakeUsersRepository.Setup(x => x.GetAll<User>(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, User>>>(),
                new[] { It.IsAny<Expression<Func<User, object>>>() }))
                .Returns(new List<User>() { fakeUser.Object });

            bool isLiked = service.LikeGame(1, "John");

            Assert.IsFalse(isLiked);
        }

        [Test]
        public void CallGameRepository_GetByIdWithCorrectParam()
        {
            var fakeUsersRepository = new Mock<IRepository<User>>();
            var fakeGameRespository = new Mock<IRepository<GameDetails>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new GamesService(
                fakeGameRespository.Object,
                It.IsAny<IRepository<GameRating>>(),
                fakeUsersRepository.Object,
                fakeUoW.Object);
            var fakeUser = new Mock<User>();
            var fakeLikedGame = new Mock<GameDetails>();
            int gameId = 1;

            fakeUser.Setup(x => x.Favorites).Returns(new List<GameDetails>() { fakeLikedGame.Object });
            fakeUsersRepository.Setup(x => x.GetAll<User>(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, User>>>(),
                new[] { It.IsAny<Expression<Func<User, object>>>() }))
                .Returns(new List<User>() { fakeUser.Object });
            fakeGameRespository.Setup(x => x.GetById(gameId)).Verifiable();

            service.LikeGame(1, "John");

            fakeGameRespository.Verify(x => x.GetById(gameId));
        }

        [Test]
        public void CommitChangesAndReturnTrue_WhenGameIsNowLiked()
        {
            var fakeUsersRepository = new Mock<IRepository<User>>();
            var fakeGameRespository = new Mock<IRepository<GameDetails>>();
            var fakeUoW = new Mock<ISlienGamesData>();
            var service = new GamesService(
                fakeGameRespository.Object,
                It.IsAny<IRepository<GameRating>>(),
                fakeUsersRepository.Object,
                fakeUoW.Object);

            var fakeUser = new Mock<User>();
            var fakeLikedGame = new Mock<GameDetails>();

            fakeUoW.Setup(x => x.Commit()).Verifiable();
            fakeUser.Setup(x => x.Favorites).Returns(new List<GameDetails>() { fakeLikedGame.Object });
            fakeUsersRepository.Setup(x => x.GetAll<User>(
                It.IsAny<Expression<Func<User, bool>>>(),
                It.IsAny<Expression<Func<User, User>>>(),
                new[] { It.IsAny<Expression<Func<User, object>>>() }))
                .Returns(new List<User>() { fakeUser.Object });
            fakeGameRespository.Setup(x => x.GetById(It.IsAny<object>())).Verifiable();

            bool isLiked = service.LikeGame(1, "John");

            Assert.IsTrue(isLiked);
            fakeUoW.Verify(x => x.Commit());
        }
    }
}

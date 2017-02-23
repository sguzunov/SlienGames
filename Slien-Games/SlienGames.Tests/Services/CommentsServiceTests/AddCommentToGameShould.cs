using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NUnit.Framework;
using Moq;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;

namespace SlienGames.Tests.Services.CommentsServiceTests
{
    [TestFixture]
    public class AddCommentToGameShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenCommentLengthIsBiggerThanAllowed()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);
            var bigCommentContent = new string('a', 250);

            Assert.Throws<ArgumentException>(() =>
            service.AddCommentToGame(gameId: 1, authorUsername: "John", content: bigCommentContent));
        }

        [Test]
        public void ThrowArgumentException_WhenGameIsNotFoundInDb()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);

            GameDetails gameToReturn = null;
            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(gameToReturn);

            Assert.Throws<ArgumentException>(() => service.AddCommentToGame(1, "John", "AlaBala"));
        }

        [Test]
        public void ThrowArgumentException_WhenAuthorIsNotFoundInDb()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);

            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Mock<GameDetails>().Object);
            fakeUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>());

            Assert.Throws<ArgumentException>(() => service.AddCommentToGame(1, "John", "AlaBala"));
        }

        [Test]
        public void CallGameRepository_ToGetTheTargetGame()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);
            var fakeFoundAuthor = new Mock<User>();
            var fakeFoundGame = new Mock<GameDetails>();

            fakeFoundGame.Setup(x => x.Comments).Returns(new Mock<ICollection<Comment>>().Object);
            fakeFoundAuthor.Setup(x => x.Id).Returns(new Guid().ToString());
            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(fakeFoundGame.Object).Verifiable();
            fakeUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { fakeFoundAuthor.Object });

            service.AddCommentToGame(1, "John", "AlaBala");

            fakeGameRepo.Verify();
        }

        [Test]
        public void CallUserRepository_ToGetTheAuthor()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);
            var fakeFoundAuthor = new Mock<User>();
            var fakeFoundGame = new Mock<GameDetails>();

            fakeFoundGame.Setup(x => x.Comments).Returns(new Mock<ICollection<Comment>>().Object);
            fakeFoundAuthor.Setup(x => x.Id).Returns(new Guid().ToString());
            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(fakeFoundGame.Object).Verifiable();
            fakeUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { fakeFoundAuthor.Object }).Verifiable();

            service.AddCommentToGame(1, "John", "AlaBala");

            fakeUserRepo.Verify();
        }

        [Test]
        public void CallUoWOnce()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);
            var fakeFoundAuthor = new Mock<User>();
            var fakeFoundGame = new Mock<GameDetails>();
            var fakeCommentsCollection = new Mock<ICollection<Comment>>();

            fakeCommentRepo.Setup(x => x.Add(It.IsAny<Comment>())).Verifiable();
            fakeUoW.Setup(x => x.Commit()).Verifiable();
            fakeFoundGame.Setup(x => x.Comments).Returns(fakeCommentsCollection.Object);
            fakeFoundAuthor.Setup(x => x.Id).Returns(new Guid().ToString());
            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(fakeFoundGame.Object).Verifiable();
            fakeUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { fakeFoundAuthor.Object }).Verifiable();

            service.AddCommentToGame(1, "John", "AlaBala");

            fakeCommentsCollection.Verify();
            fakeUoW.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ReturnACommentObject_WithCorrectlySetupedAuthorAndGame()
        {
            var fakeUserRepo = this.GetFakeUserRepository();
            var fakeCommentRepo = this.GetFakeCommentRepository();
            var fakeGameRepo = this.GetFakeGameDetailsRepository();
            var fakeUoW = this.GetFakeUnitOfWork();
            var service = new CommentsService(fakeUserRepo.Object, fakeCommentRepo.Object, fakeGameRepo.Object, fakeUoW.Object);
            var fakeFoundAuthor = new Mock<User>();
            var fakeFoundGame = new Mock<GameDetails>();
            var fakeCommentsCollection = new Mock<ICollection<Comment>>();

            fakeFoundGame.Setup(x => x.Comments).Returns(new Mock<ICollection<Comment>>().Object);
            fakeFoundAuthor.Setup(x => x.Id).Returns(new Guid().ToString());
            fakeGameRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(fakeFoundGame.Object).Verifiable();
            fakeUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>())).Returns(new List<User>() { fakeFoundAuthor.Object }).Verifiable();

            var comment = service.AddCommentToGame(1, "John", "AlaBala");

            Assert.AreEqual(fakeFoundAuthor.Object, comment.Author);
            Assert.AreEqual(fakeFoundGame.Object, comment.GameDetails);
        }

        private Mock<IRepository<User>> GetFakeUserRepository()
        {
            return new Mock<IRepository<User>>();
        }

        private Mock<IRepository<Comment>> GetFakeCommentRepository()
        {
            return new Mock<IRepository<Comment>>();
        }

        private Mock<IRepository<GameDetails>> GetFakeGameDetailsRepository()
        {
            return new Mock<IRepository<GameDetails>>();
        }

        private Mock<ISlienGamesData> GetFakeUnitOfWork()
        {
            return new Mock<ISlienGamesData>();
        }
    }
}

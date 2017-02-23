using System;
using System.Linq.Expressions;

using Moq;
using NUnit.Framework;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services;

namespace SlienGames.Tests.Services.CommentsServiceTests
{
    [TestFixture]
    public class GetDetailsWithCommentsByNameShould
    {
        [Test]
        public void CallCommentsRepository()
        {
            var fakeCommentsRepository = new Mock<IRepository<Comment>>();
            var service = new CommentsService(
                It.IsAny<IRepository<User>>(),
                fakeCommentsRepository.Object,
                It.IsAny<IRepository<GameDetails>>(),
                It.IsAny<ISlienGamesData>());

            fakeCommentsRepository.Setup(x => x.GetAll<Comment>(
                It.IsAny<Expression<Func<Comment, bool>>>(),
                It.IsAny<Expression<Func<Comment, Comment>>>(),
                new[] { It.IsAny<Expression<Func<Comment, object>>>() }))
                .Verifiable();

            service.GetGameComments(It.IsAny<int>());

            fakeCommentsRepository.Verify();
        }
    }
}

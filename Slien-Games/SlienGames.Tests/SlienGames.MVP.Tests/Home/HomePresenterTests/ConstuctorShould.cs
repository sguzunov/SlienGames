using Moq;
using NUnit.Framework;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;
using System.Linq.Expressions;
using SlienGames.Data.Models;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Home.HomePresenterTests
{
    [TestFixture]
    public class ConstuctorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUsersServiceNull()
        {
            var mockedView = new Mock<IHomeView>();

            var exc = Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedView.Object, null,null));

            Assert.That(exc.Message.Contains("is null"));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenReviewsServiceIsNull()
        {
            var mockedView = new Mock<IHomeView>();
            var mockedUsersService = new Mock<IUsersService>();

            var exc = Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedView.Object, mockedUsersService.Object, null));

            Assert.That(exc.Message.Contains("is null"));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IHomeView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var presenter = new HomePresenter(mockedView.Object, mockedUsersService.Object, mockedReviewsService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IHomeView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedReviewsService = new Mock<IReviewsService>();

            var presenter = new HomePresenter(mockedView.Object, mockedUsersService.Object,mockedReviewsService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IHomeView>>());
        }

        [Test]
        public void CallUsersServiceGetAllMethodOnce_WhenViewsMethodIsRaised()
        {
            var mockedView = new Mock<IHomeView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedReviewsService = new Mock<IReviewsService>();

            var mockedModel = new Mock<HomeModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var fakeResult = new List<User>();
            mockedUsersService.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>(),It.IsAny<Expression<Func<User, int>>>())).Returns(fakeResult);

            var presenter = new HomePresenter(mockedView.Object, mockedUsersService.Object,mockedReviewsService.Object);
            mockedView.Raise(x => x.GetTopUsers += null, null, null);

            mockedUsersService.Verify(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, int>>>()), Times.Once);
        }
    }
}
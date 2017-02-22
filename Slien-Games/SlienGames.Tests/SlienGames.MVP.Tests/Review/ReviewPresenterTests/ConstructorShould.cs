using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Review;
using System;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.ReviewTests.ReviewPresenterTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenReviewServiceIsNull()
        {
            var mockedView = new Mock<IReviewView>();

            Assert.Throws<ArgumentNullException>(() => new ReviewPresenter(mockedView.Object, null));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IReviewView>();
            var mockedReviewService = new Mock<IReviewsService>();

            var presenter = new ReviewPresenter(mockedView.Object, mockedReviewService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IReviewView>();
            var mockedReviewService = new Mock<IReviewsService>();

            var presenter = new ReviewPresenter(mockedView.Object,mockedReviewService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IReviewView>>());
        }

        [Test]
        public void CallReviewsServiceGetByIdMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IReviewView>();
            var mockedModel = new Mock<ReviewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            var mockedReviewService = new Mock<IReviewsService>();
            var review = new Mock<Review>();
            var presenter = new ReviewPresenter(mockedView.Object, mockedReviewService.Object);

            mockedView.Raise(x => x.GetCurrentReview += null, null, new ReviewEventArgs(1));

            mockedReviewService.Verify(x => x.GetUserById(It.IsAny<object>()), Times.Once);
        }
    }
}

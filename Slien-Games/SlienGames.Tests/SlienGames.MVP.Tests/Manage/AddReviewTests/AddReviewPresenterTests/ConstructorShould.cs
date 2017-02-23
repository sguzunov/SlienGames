using Moq;
using NUnit.Framework;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Manage.AddReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.AddReviewTests.AddReviewPresenterTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenUserPresenterIsNull()
        {
            var mockedView = new Mock<IAddReviewView>();

            Assert.Throws<ArgumentNullException>(() => new AddReviewPresenter(mockedView.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenFileSaverIsNull()
        {
            var mockedView = new Mock<IAddReviewView>();
            var mockedUserPresenter = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new AddReviewPresenter(mockedView.Object, mockedUserPresenter.Object, null));
        }


        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<IAddReviewView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>();

            var presenter = new AddReviewPresenter(mockedView.Object, mockedUsersService.Object,mockedFileSaver.Object);

            Assert.That(presenter, Is.Not.Null);
        }


        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<IAddReviewView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>();

            var presenter = new AddReviewPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<IAddReviewView>>());
        }

        [Test]
        public void CallUsersServiceAddReviewMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IAddReviewView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>(); 
            var presenter = new AddReviewPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            mockedView.Raise(x => x.SaveReview += null, null,
                new AddReviewEventArgs("gosho", "pesho", "stamat", new byte[1], 1, "mariika", "deeba", "svurshiha"));

            mockedUsersService.Verify(x => x.AddReview(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>(),
                It.IsAny<string>(), 
                It.IsAny<string>()),Times.Once);
        }


        [Test]
        public void CallFileSaversSaveMethod_WhenViewsEventIsRaised()
        {
            var mockedView = new Mock<IAddReviewView>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var presenter = new AddReviewPresenter(mockedView.Object, mockedUsersService.Object, mockedFileSaver.Object);

            mockedView.Raise(x => x.SaveReview += null, null,
                new AddReviewEventArgs("gosho", "pesho", "stamat", new byte[1], 1, "mariika", "deeba", "svurshiha"));

            mockedFileSaver.Verify(x =>x.SaveFile(It.IsAny<string>(),It.IsAny<byte[]>()), Times.Once);
        }

    }
}

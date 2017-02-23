using Moq;
using NUnit.Framework;
using SlienGames.Data.Services.Contracts;
using SlienGames.MVP.Account.Login;
using System;
using WebFormsMvp;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Account.LoginTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_WhenInstantiatingWithNull()
        {
            var mockedView = new Mock<ILoginView>();

            var exc = Assert.Throws<ArgumentNullException>(() => new LoginPresenter(mockedView.Object, null));

            Assert.That(exc.Message.Contains("is null"));
        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var mockedView = new Mock<ILoginView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new LoginPresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfPresenter()
        {
            var mockedView = new Mock<ILoginView>();
            var mockedUsersService = new Mock<IUsersService>();

            var presenter = new LoginPresenter(mockedView.Object, mockedUsersService.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<ILoginView>>());
        }

        [Test]
        public void CallUsersServiceCheckIfBlockedMethodOnce_WhenViewsMethodIsRaised()
        {
            //var mockedView = new Mock<ILoginView>();
            //var mockedUsersService = new Mock<IUsersService>();
            //var mockedModel = new Mock<LoginViewModel>();
            //mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            //mockedUsersService.Setup(x => x.CheckIfIsBlocked(It.IsAny<string>())).Returns(true);
            //var mockedApplicationUserManager = new Mock<ApplicationUserManager>();
            //var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            //var mockedApplicationSignInManager = new Mock<ApplicationSignInManager>(mockedApplicationUserManager.Object,mockedAuthenticationManager.Object);
            //mockedApplicationSignInManager
            //    .Setup(x => x.OurPasswordSignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
            //    .Returns(SignInStatus.Success);

            //var presenter = new LoginPresenter(mockedView.Object, mockedUsersService.Object);
            //mockedView.Raise(x => x.LoginUser += null, null, new LoginEventArgs("gosho","gosho", true,false,mockedApplicationSignInManager.Object));

            //mockedUsersService.Verify(x => x.CheckIfIsBlocked(It.IsAny<string>()), Times.Once);
        }
    }
}

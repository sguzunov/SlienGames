using Moq;
using NUnit.Framework;
using SlienGames.Web.Presenters;
using SlienGames.Web.Services;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Web.Tests.Presenters.Tests.UserPresenterTests
{
    [TestFixture]
    public  class Constructor_Should
    {
        [Test]
        public void AddReferenceOfTheMethodInThePresenterInTheView_WhenInstatianting()
        {
            var view = new Mock<IUserView>();
            var provider = new Mock<IDataProvider>();

            var userPresenter = new UserPresenter(view.Object, provider.Object);

            
        }
    }
}

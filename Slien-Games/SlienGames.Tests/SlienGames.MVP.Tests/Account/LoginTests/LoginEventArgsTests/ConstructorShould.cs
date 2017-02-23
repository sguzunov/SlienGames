using NUnit.Framework;
using SlienGames.MVP.Account.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Account.LoginTests.LoginArgTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenUsernameIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs(null, null, false, false, null));
            Assert.True(ex.Message.Contains("is null"));
        }

        [Test]
        public void ThrowWhenPasswordIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs("gosho", null, false, false, null));
            Assert.True(ex.Message.Contains("is null"));
        }

        [Test]
        public void ThrowWhenSignInManagerIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs("gosho", "pesho", false, false, null));
            Assert.True(ex.Message.Contains("is null"));
        }
    }
}

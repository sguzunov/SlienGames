using NUnit.Framework;
using SlienGames.MVP.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Account.RegisterTests.RegisterEventArgsTests
{
    [TestFixture]
    class ConstructorShould
    {

        [Test]
        public void ThrowWhenUsernameIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs(null, null, null, null, null));
            Assert.True(ex.Message.Contains("is null"));
        }

        [Test]
        public void ThrowWhenPasswordIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs("gosho", null, null, null, null));
            Assert.True(ex.Message.Contains("is null"));
        }
        [Test]
        public void ThrowWhenEmailIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs("gosho", "gosho", null, null, null));
            Assert.True(ex.Message.Contains("is null"));
        }

        [Test]
        public void ThrowWhenApplicationUserManagerIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs("gosho", "gosho", "pesho", null, null));
            Assert.True(ex.Message.Contains("is null"));
        }
    }
}

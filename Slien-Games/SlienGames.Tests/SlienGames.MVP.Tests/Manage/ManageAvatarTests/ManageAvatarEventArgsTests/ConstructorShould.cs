using NUnit.Framework;
using SlienGames.MVP.Manage.ManageAvatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.ManageAvatarTests.ManageAvatarEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {

        [Test]
        public void ThrowWhenFileNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageAvatarEventArgs(null,null,null,null,null));
        }

        [Test]
        public void ThrowWhenFileExtensionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageAvatarEventArgs("gosho" , null, null, null, null));
        }

        [Test]
        public void ThrowWhenFilePathIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageAvatarEventArgs("gosho", "pesho", null, null, null));
        }

        [Test]
        public void ThrowWhenAllbytesIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageAvatarEventArgs("gosho", "pesho", "testis", null, null));
        }

        [Test]
        public void ThrowWhenUserIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageAvatarEventArgs("gosho", "pesho", "testis", new byte[1], null));
        }
    }
}

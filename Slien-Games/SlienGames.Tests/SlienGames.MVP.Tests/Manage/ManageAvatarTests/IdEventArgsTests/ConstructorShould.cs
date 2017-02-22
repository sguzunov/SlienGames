using NUnit.Framework;
using SlienGames.MVP.Manage.ManageAvatar;
using System;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.ManageAvatarTests.IdEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new IdEventArgs(null));
        }
    }
}

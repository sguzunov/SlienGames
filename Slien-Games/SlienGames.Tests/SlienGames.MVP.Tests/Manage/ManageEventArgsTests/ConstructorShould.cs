using NUnit.Framework;
using SlienGames.MVP.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.ManageEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ManageEventArgs(null));

        }
    }

}

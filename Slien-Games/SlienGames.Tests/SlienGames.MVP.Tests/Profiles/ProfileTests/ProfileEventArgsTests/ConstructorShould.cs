using NUnit.Framework;
using SlienGames.MVP.Profiles.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Profiles.ProfileTests.ProfileEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ProfileEventArgs(null));
        }
    }
}

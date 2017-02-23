using NUnit.Framework;
using SlienGames.MVP.ReviewMVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.ReviewTests.ReviewEventArgsTests
{
    [TestFixture]
    class ContructorShould
    {
        [Test]
        public void ThrowWhenIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ReviewEventArgs(null));
        }
    }
}

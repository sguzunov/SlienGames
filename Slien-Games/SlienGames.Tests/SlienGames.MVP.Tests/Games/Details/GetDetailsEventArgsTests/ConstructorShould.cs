using NUnit.Framework;
using SlienGames.MVP.Games.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Games.Details.GetDetailsEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowWhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new GetDetailsEventArgs(null));

        }

        [Test]
        public void InitializeCorrectly_WhenParametersAreValid()
        {
            var args = new GetDetailsEventArgs("gosho");

            Assert.That(args, Is.Not.Null);
        }
        
    }
}

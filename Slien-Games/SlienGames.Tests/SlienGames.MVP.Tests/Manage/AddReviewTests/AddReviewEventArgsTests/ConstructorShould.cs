using NUnit.Framework;
using SlienGames.MVP.Manage.AddReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.MVP.Tests.Manage.AddReviewTests.AddReviewEventArgsTests
{
    [TestFixture]
    public class ConstructorShould
    {

        [Test]
        public void ThrowWhenCoverImageNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenCoverImageExtensionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                null,
                null,
                null,
                null,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenCoverImagePathIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                null,
                null,
                null,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenCoverImageAllBytesIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                "stamat",
                null,
                null,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenUserIdIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                "stamat",
                new byte[1],
                null,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenTitleIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                "stamat",
                new byte[1],
                1,
                null,
                null,
                null));

        }

        [Test]
        public void ThrowWhenVideoUrlIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                "stamat",
                new byte[1],
                1,
                "mariika",
                null,
                null));

        }

        [Test]
        public void ThrowWhenDescriptionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AddReviewEventArgs(
                "gosho",
                "pesho",
                "stamat",
                new byte[1],
                1,
                "mariika",
                "stokata",
                null));

        }        
    }
}

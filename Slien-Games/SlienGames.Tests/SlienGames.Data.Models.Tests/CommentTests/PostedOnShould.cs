using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class PostedOnShould
    {
        [Test]
        public void Be_TypeOfDateTime()
        {
            var comment = new Comment();
            var date = new DateTime();
            comment.PostedOn = date;

            var result = comment.PostedOn.GetType();

            Assert.True(result == typeof(DateTime));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var comment = new Comment();
            var date = new DateTime();

            comment.PostedOn = date;

            Assert.True(comment.PostedOn == date);
        }
    }
}

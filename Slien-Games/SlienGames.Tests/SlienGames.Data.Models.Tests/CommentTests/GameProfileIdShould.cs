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
    public class GameProfileIdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var comment = new Comment();           
            comment.GameProfileId = 1;

            var result = comment.GameProfileId.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var comment = new Comment();

            comment.GameProfileId = 1;

            Assert.True(comment.GameProfileId == 1);
        }
    }
}

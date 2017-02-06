using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class CommentType
    {
        [Test]
        public void ShouldBe_IDbModel()
        {
            var comment = new Comment();

            var result = comment.GetType().GetInterfaces().Any(x => x == typeof(IDbModel));

            Assert.True(result);
        }
    }
}

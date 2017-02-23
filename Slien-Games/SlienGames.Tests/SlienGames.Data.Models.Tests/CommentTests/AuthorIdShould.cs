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
    public class AuthorIdShould
    {
        [Test]
        public void Be_TypeOGuid()
        {
            var comment = new Comment();

            var result = comment.AuthorId.GetType();

            Assert.True(result == typeof(Guid));
        }
    }
}

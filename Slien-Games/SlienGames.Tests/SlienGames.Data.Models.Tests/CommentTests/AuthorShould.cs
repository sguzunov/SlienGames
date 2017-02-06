using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class AuthorShould
    {
        [Test] 
        public void Be_TypeOfUser()
        {
            var comment = new Comment();
            var user = new User();
            comment.Author = user;

            var result = comment.Author.GetType();

            Assert.True(result == typeof(User));
        }

        [Test]
        public void GetAndSeT_ShouldBePublic()
        {
            var comment = new Comment();
            var user = new User();

            comment.Author = user;

            Assert.True(comment.Author == user);
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Author")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);

        }
    }
}

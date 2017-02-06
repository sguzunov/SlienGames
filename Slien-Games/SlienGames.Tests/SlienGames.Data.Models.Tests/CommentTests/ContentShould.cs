using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class ContentShould
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Content")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);
            
        }

        [Test]
        public void HaveMinLengthAttribute()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Content")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMaxLengthAttribute()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Content")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMinLengthAttribute_WithRightValue()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Content")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.CommentContentMinLength, result.Length);
                
        }

        [Test]
        public void HaveMaxLengthAttribute_WithRightValue()
        {
            var comment = new Comment();

            var result = comment
                .GetType()
                .GetProperty("Content")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.CommentContentMaxLength, result.Length);
        }

        [TestCase("Mnol si lo6 batko")]
        [TestCase("Tova ne e verno, vijdal sam ma nqma")]
        public void GetAndSet_ShouldBePublic(string test)
        {
            var comment = new Comment();
            comment.Content = test;

            Assert.AreEqual(test, comment.Content);
        }

        [TestCase("Mnol si lo6 batko")]
        [TestCase("Tova ne e verno, vijdal sam ma nqma")]
        public void Be_TypeOfString(string test)
        {
            var comment = new Comment();
            comment.Content = test;

            var result = comment.Content.GetType();

            Assert.True(result == typeof(string));
        }
    }
}

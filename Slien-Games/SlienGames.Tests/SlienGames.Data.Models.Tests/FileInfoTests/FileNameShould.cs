using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.FileInfoTests
{
    [TestFixture]
    public class FileNameShould
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileName")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);

        }
        [Test]
        public void HaveMaxLengthAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileName")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMaxLengthAttribute_WithRightValue()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileName")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.FileInfoFileNameMaxLength, result.Length);
        }

        [TestCase("gosho")]
        [TestCase("pesho")]
        public void GetAndSet_ShouldBePublic(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileName = test;

            Assert.AreEqual(test, fileInfo.FileName);
        }

        [TestCase("gosho")]
        [TestCase("pesho")]
        public void Be_TypeOfString(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileName = test;

            var result = fileInfo.FileName.GetType();

            Assert.True(result == typeof(string));
        }
    }
}

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
    public class FileExtensionShould
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileExtension")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);

        }

        [Test]
        public void HaveMinLengthAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileExtension")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMaxLengthAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileExtension")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMinLengthAttribute_WithRightValue()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileExtension")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.FileInfoFileExtensionMinLength, result.Length);

        }

        [Test]
        public void HaveMaxLengthAttribute_WithRightValue()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("FileExtension")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.FileInfoFileExtensionMaxLength, result.Length);
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void GetAndSet_ShouldBePublic(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileExtension = test;

            Assert.AreEqual(test, fileInfo.FileExtension);
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Be_TypeOfString(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileExtension = test;

            var result = fileInfo.FileExtension.GetType();

            Assert.True(result == typeof(string));
        }
    }
}

using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.FileInfoTests
{
    [TestFixture]
    public class FileSystemUrlPathShould
    {
        [TestCase("gosho/joro")]
        [TestCase("pesho/joro/stamat")]
        public void GetAndSet_ShouldBePublic(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileSystemUrlPath = test;

            Assert.AreEqual(test, fileInfo.FileSystemUrlPath);
        }

        [TestCase("gosho/joro")]
        [TestCase("pesho/joro/stamat")]
        public void Be_TypeOfString(string test)
        {
            var fileInfo = new FileInfo();
            fileInfo.FileSystemUrlPath = test;

            var result = fileInfo.FileSystemUrlPath.GetType();

            Assert.True(result == typeof(string));
        }
    }
}

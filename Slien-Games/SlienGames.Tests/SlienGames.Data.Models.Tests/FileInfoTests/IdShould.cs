using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.FileInfoTests
{
    [TestFixture]
    public class IdShould
    {
        [Test]
        public void Be_TypeOfInt()
        {
            var fileInfo = new FileInfo();
            fileInfo.Id = 1;

            var result = fileInfo.Id.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void GetAndSet_ShouldBePublic()
        {
            var fileInfo = new FileInfo();

            fileInfo.Id = 1;

            Assert.True(fileInfo.Id == 1);
        }

        [Test]
        public void HaveKeyAttribute()
        {
            var fileInfo = new FileInfo();

            var result = fileInfo
                .GetType()
                .GetProperty("Id")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(KeyAttribute))
                .Any();

            Assert.True(result);

        }
    }
}

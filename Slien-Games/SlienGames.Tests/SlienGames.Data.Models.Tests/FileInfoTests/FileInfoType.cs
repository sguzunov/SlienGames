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
    public class FileInfoType
    {
        [Test]
        public void ShouldBe_IDbModel()
        {
            var fileInfo = new FileInfo();

            //var result = fileInfo.GetType().GetInterfaces().Any(x => x == typeof(IDbModel));

            //Assert.True(result);
        }
    }
}

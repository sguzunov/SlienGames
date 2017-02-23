using Moq;
using NUnit.Framework;
using SlienGames.Data;
using SlienGames.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ShouldCall_DbSetFindMethodOnce()
        {
            //var fakeDbModel = new Mock<IDbModel>();
            //var fakeDbSet = new Mock<DbSet<IDbModel>>();
            //var mockDbContext = new Mock<ISlienGamesDbContext>();
            //mockDbContext.Setup(x => x.Set<IDbModel>()).Returns(fakeDbSet.Object);
            //fakeDbSet.Setup(x => x.Find(It.IsAny<object>())).Returns(fakeDbModel.Object);
            //var repo = new EfRepository<IDbModel>(mockDbContext.Object);

            //repo.GetById(new { });

            //fakeDbSet.Verify(x => x.Find(It.IsAny<object>()), Times.Once);
        }
    }
}

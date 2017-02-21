using Moq;
using NUnit.Framework;
using SlienGames.Data;
using SlienGames.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class AddShould
    {
       
        public void ShouldCall_DbContextEntryMethodOnce()
        {
            //var fakeDbEntityEntry = new Mock<DbEntityEntry<IDbModel>>();
            //var fakeDbModel = new Mock<IDbModel>();
            //var fakeDbSet = new Mock<DbSet<IDbModel>>();
            //var mockDbContext = new Mock<ISlienGamesDbContext>();
            //mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);
            //mockDbContext.Setup(mock => mock.Entry(It.IsAny<IDbModel>())).Returns(fakeDbEntityEntry.Object);
            //fakeDbEntityEntry.Setup(mock => mock.State).Returns(EntityState.Detached);
            //var repo = new EfRepository<IDbModel>(mockDbContext.Object);

            //repo.Add(fakeDbModel.Object);

            //mockDbContext.Verify(x => x.Entry(It.IsAny<IDbModel>()), Times.Once);
        }
    }
}

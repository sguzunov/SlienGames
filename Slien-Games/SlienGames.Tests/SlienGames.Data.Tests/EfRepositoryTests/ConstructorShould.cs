using Moq;
using NUnit.Framework;
using SlienGames.Data;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Tests.EfRepositoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ShouldThrowArgumentNullExceptionWithProperMessage_WhenIWhenItsDoneDbContextParameterIsNull()
        {
            //Assert.That(() => new EfRepository<IDbModel>(null),
            //    Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DB context"));
        }

        [Test]
        public void ShouldCall_DbContextSetMethodOnce()
        {
            //var fakeDbSet = new Mock<DbSet<IDbModel>>();
            //var mockDbContext = new Mock<ISlienGamesDbContext>();
            //mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            //var repo = new EfRepository<IDbModel>(mockDbContext.Object);

            //mockDbContext.Verify(x => x.Set<IDbModel>(), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenDbContextDoesNotContainADbSetOfThisType()
        {
        //    var mockDbContext = new Mock<ISlienGamesDbContext>();
        //    mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns<DbSet<IDbModel>>(null);

        //    Assert.That(
        //        () => new EfRepository<IDbModel>(mockDbContext.Object),
        //        Throws.InstanceOf<ArgumentException>().With.Message.Contains("DbContext does not"));
        }
    }
}

﻿using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Contracts;
using System.Linq;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CoverImageTests
{
    [TestFixture]
    public class CoverImageType
    {
        [Test]
        public void ShouldBe_IDbModel()
        {
            var coverImager = new CoverImage();

            var result = coverImager
                .GetType()
                .GetInterfaces().Any(x => x == typeof(IDbModel));

            Assert.True(result);
        }
    }
}

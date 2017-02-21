using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameDetailsTests
{
    [TestFixture]
    public class NameShould
    {
        [Test]
        public void HaveRequiredAttribute()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.True(result);

        }

        [Test]
        public void HaveIndexAttribute()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(IndexAttribute))
                .Any();

            Assert.True(result);

        }

        [Test]
        public void HaveMinLengthAttribute()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMaxLengthAttribute()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMinLengthAttribute_WithRightValue()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.GameProfileNameMinLength, result.Length);

        }

        [Test]
        public void HaveMaxLengthAttribute_WithRightValue()
        {
            var gameProfile = new GameDetails();

            var result = gameProfile
                .GetType()
                .GetProperty("Name")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(ValidationConstants.GameProfileNameMaxLength, result.Length);
        }

        [TestCase("witcher")]
        [TestCase("farcry")]
        public void GetAndSet_ShouldBePublic(string test)
        {
            var gameProfile = new GameDetails();
            gameProfile.Name = test;

            Assert.AreEqual(test, gameProfile.Name);
        }

        [TestCase("witcher")]
        [TestCase("farcry")]
        public void Be_TypeOfString(string test)
        {
            var gameProfile = new GameDetails();
            gameProfile.Name = test;

            var result = gameProfile.Name.GetType();

            Assert.True(result == typeof(string));
        }
    }
}

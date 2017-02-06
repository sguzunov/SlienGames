using NUnit.Framework;
using SlienGames.Data.Models;
using SlienGames.Data.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameProfileTests
{
    [TestFixture]
    public class DescriptionShould
    {
        [TestFixture]
        public class FileExtensionShould
        {
            [Test]
            public void HaveRequiredAttribute()
            {
                var gameProfile = new GameProfile();

                var result = gameProfile
                    .GetType()
                    .GetProperty("Description")
                    .GetCustomAttributes(false)
                    .Where(x => x.GetType() == typeof(RequiredAttribute))
                    .Any();

                Assert.True(result);

            }

            [Test]
            public void HaveMinLengthAttribute()
            {
                var gameProfile = new GameProfile();

                var result = gameProfile
                    .GetType()
                    .GetProperty("Description")
                    .GetCustomAttributes(false)
                    .Where(x => x.GetType() == typeof(MinLengthAttribute))
                    .Any();

                Assert.True(result);
            }

            [Test]
            public void HaveMaxLengthAttribute()
            {
                var gameProfile = new GameProfile();

                var result = gameProfile
                    .GetType()
                    .GetProperty("Description")
                    .GetCustomAttributes(false)
                    .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                    .Any();

                Assert.True(result);
            }

            [Test]
            public void HaveMinLengthAttribute_WithRightValue()
            {
                var gameProfile = new GameProfile();

                var result = gameProfile
                    .GetType()
                    .GetProperty("Description")
                    .GetCustomAttributes(false)
                    .Where(x => x.GetType() == typeof(MinLengthAttribute))
                    .Select(x => (MinLengthAttribute)x)
                    .SingleOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual(ValidationConstants.GameProfileDescriptionMinLength, result.Length);

            }

            [Test]
            public void HaveMaxLengthAttribute_WithRightValue()
            {
                var gameProfile = new GameProfile();

                var result = gameProfile
                    .GetType()
                    .GetProperty("Description")
                    .GetCustomAttributes(false)
                    .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                    .Select(x => (MaxLengthAttribute)x)
                    .SingleOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual(ValidationConstants.GameProfileDescriptionMaxLength, result.Length);
            }

            [TestCase("mnol dobra taz igra")]
            [TestCase("ftw so majestic")]
            public void GetAndSet_ShouldBePublic(string test)
            {
                var gameProfile = new GameProfile();
                gameProfile.Description = test;

                Assert.AreEqual(test, gameProfile.Description);
            }

            [TestCase("mnol dobra taz igra")]
            [TestCase("ftw so majestic")]
            public void Be_TypeOfString(string test)
            {
                var gameProfile = new GameProfile();
                gameProfile.Description = test;

                var result = gameProfile.Description.GetType();

                Assert.True(result == typeof(string));
            }
        }
    }
}

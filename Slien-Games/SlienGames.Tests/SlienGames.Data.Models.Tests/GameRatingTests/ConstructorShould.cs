using NUnit.Framework;
using System;
using System.Reflection;

using SlienGames.Data.Models;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.VoteTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(GameRating);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }
    }
}

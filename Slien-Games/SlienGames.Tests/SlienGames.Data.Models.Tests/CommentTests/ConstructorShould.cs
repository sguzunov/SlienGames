using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Reflection;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.CommentTests
{
    [TestFixture]
   public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(Comment);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }
    }
}

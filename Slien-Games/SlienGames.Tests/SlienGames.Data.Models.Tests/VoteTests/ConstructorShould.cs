using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.VoteTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(Vote);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }
        [Test]
        public void InitializeVotesCorrectly()
        {
            var vote = new Vote();

            var games = vote.Games;

            Assert.That(games, Is.Not.Null.And.InstanceOf<HashSet<GameProfile>>());
        }
    }
}

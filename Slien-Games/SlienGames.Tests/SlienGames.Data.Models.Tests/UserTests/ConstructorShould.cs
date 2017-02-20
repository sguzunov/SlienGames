using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(User);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }
        [Test]
        public void InitializeGamesCommentsCorrectly()
        {
            var user = new User();

            var gamesComments = user.GamesComments;

            Assert.That(gamesComments, Is.Not.Null.And.InstanceOf<HashSet<Comment>>());
        }

        [Test]
        public void InitializeVotesCorrectly()
        {
            var user = new User();

            var votedGames = user.VotedGames;

            Assert.That(votedGames, Is.Not.Null.And.InstanceOf<HashSet<GameDetails>>());
        }
    }
}

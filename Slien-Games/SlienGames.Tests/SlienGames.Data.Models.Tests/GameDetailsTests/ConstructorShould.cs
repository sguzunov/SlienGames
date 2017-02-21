using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameProfileTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(GameDetails);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void InitializeCommentsCorrectly()
        {
            var gameProfile = new GameDetails();

            var comments = gameProfile.Comments;

            Assert.That(comments, Is.Not.Null.And.InstanceOf<HashSet<Comment>>());
        }

        [Test]
        public void InitializeUsersVotedThisGameCorrectly()
        {
            var gameProfile = new GameDetails();

            var usersVotedThisGame = gameProfile.UsersVotedThisGame;

            Assert.That(usersVotedThisGame, Is.Not.Null.And.InstanceOf<HashSet<User>>());
        }
    }
}

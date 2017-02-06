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
            var type = typeof(GameProfile);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }
        [Test]
        public void InitializeVotesCorrectly()
        {
            var gameProfile = new GameProfile();

            var votes = gameProfile.Votes;

            Assert.That(votes, Is.Not.Null.And.InstanceOf<HashSet<Vote>>());
        }

        [Test]
        public void InitializeCommentsCorrectly()
        {
            var gameProfile = new GameProfile();

            var comments = gameProfile.Comments;

            Assert.That(comments, Is.Not.Null.And.InstanceOf<HashSet<Comment>>());
        }

        [Test]
        public void InitializeUsersVotedThisGameCorrectly()
        {
            var gameProfile = new GameProfile();

            var usersVotedThisGame = gameProfile.UsersVotedThisGame;

            Assert.That(usersVotedThisGame, Is.Not.Null.And.InstanceOf<HashSet<User>>());
        }
    }
}

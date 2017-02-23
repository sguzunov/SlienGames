using NUnit.Framework;
using SlienGames.Data;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Tests.SlienGamesDbContextTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(SlienGamesDbContext);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void BeInstanceOfDbContext()
        {
            var context = new SlienGamesDbContext();

            Assert.That(context, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void BeInstanceOfISlienGamesDbContext()
        {
            var context = new SlienGamesDbContext();

            Assert.That(context, Is.InstanceOf<ISlienGamesDbContext>());
        }

        [Test]
        public void CreateInstanceWithCommentProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Comments", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }
        [Test]
        public void CreateInstanceWithCommentVirtualProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Comments", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
        [Test]
        public void CreateInstanceWithCommentVirtualPropertyOfTypeIDbSet()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Comments", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Comment>)));
        }

        [Test]
        public void CreateInstanceWithGamesDetailsProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesDetails", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }
        [Test]
        public void CreateInstanceWithGamesDetailsVirtualProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesDetails", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
        [Test]
        public void CreateInstanceWithGamesDetailsVirtualPropertyOfTypeIDbSet()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesDetails", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<GameDetails>)));
        }

        [Test]
        public void CreateInstanceWithGamesRatingsProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesRatings", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }
        [Test]
        public void CreateInstanceWithGamesRatingsVirtualProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesRatings", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
        [Test]
        public void CreateInstanceWithGameRatingsVirtualPropertyOfTypeIDbSet()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("GamesRatings", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<GameRating>)));
        }

        [Test]
        public void CreateInstanceWithProfileImagesProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("ProfileImages", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }
        [Test]
        public void CreateInstanceWithProfileImagesVirtualProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("ProfileImages", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
        [Test]
        public void CreateInstanceWithProfileImagesVirtualPropertyOfTypeIDbSet()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("ProfileImages", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ProfileImage>)));
        }


        [Test]
        public void CreateInstanceWithCoverImagesProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("CoverImages", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }
        [Test]
        public void CreateInstanceWithCoverImagesVirtualProperty()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("CoverImages", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
        [Test]
        public void CreateInstanceWithCoverImagesVirtualPropertyOfTypeIDbSet()
        {
            var context = new SlienGamesDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("CoverImages", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<CoverImage>)));
        }
    }
}

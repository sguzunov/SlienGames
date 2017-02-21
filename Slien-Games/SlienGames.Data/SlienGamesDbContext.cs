using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Microsoft.AspNet.Identity.EntityFramework;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;

namespace SlienGames.Data
{
    public class SlienGamesDbContext : IdentityDbContext<User>, ISlienGamesDbContext
    {
        public SlienGamesDbContext() : base("SlienGamesConnection")
        {
        }

        public static SlienGamesDbContext Create()
        {
            var instance = new SlienGamesDbContext();
            return instance;
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<GameDetails> GamesDetails { get; set; }

        public IDbSet<ExternalGameResource> ExternalGameResources { get; set; }

        public IDbSet<ProfileImage> ProfileImages { get; set; }

        public IDbSet<CoverImage> CoverImages { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<ReviewImage> ReviewImages { get; set; }

        public IDbSet<GameRating> GamesRatings { get; set; }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - ProfileImage (one-to-one or zero)
            modelBuilder.Entity<User>()
                .HasOptional(x => x.ProfileImage)
                .WithRequired(x => x.User);

            // GameDetails - CoverImage (one-to-one or zero)
            modelBuilder.Entity<GameDetails>()
                .HasOptional(x => x.CoverImage)
                .WithRequired(x => x.Game);

            modelBuilder.Entity<Review>()
                .HasOptional(x => x.Picture)
                .WithRequired(x => x.Review);

            // GameDetails - ExternalGameResource (one-to-one or zero)
            modelBuilder.Entity<GameDetails>()
                .HasOptional(x => x.ExternalResource)
                .WithRequired(x => x.Game);
        }
    }
}

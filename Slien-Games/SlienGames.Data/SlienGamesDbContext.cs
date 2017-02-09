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

        public IDbSet<GameProfile> GamesProfiles { get; set; }
       

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<ProfileImage> ProfileImages { get; set; }

        public IDbSet<CoverImage> CoverImages { get; set; }

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

        //public new int SaveChanges()
        //{
        //    return this.SaveChanges();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - ProfileImage (one-to-one or zero)
            modelBuilder.Entity<User>()
                .HasOptional(x => x.ProfileImage)
                .WithRequired(x => x.User);

            // GameProfile - CoverImage (one-to-one or zero)
            modelBuilder.Entity<GameProfile>()
                .HasOptional(x => x.CoverImage)
                .WithRequired(x => x.Game);
        }
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SlienGames.Data.Models;

namespace SlienGames.Data
{
    public class SlienGamesDbContext : DbContext, ISlienGamesDbContext
    {
        protected SlienGamesDbContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<GameProfile> GamesProfiles { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Vote> Votes { get; set; }

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
        }
    }
}

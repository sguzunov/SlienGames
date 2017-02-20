using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using SlienGames.Data.Models;

namespace SlienGames.Data.Contracts
{
    public interface ISlienGamesDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<GameDetails> GamesDetails { get; set; }

        IDbSet<ExternalGameResource> ExternalGameResources { get; set; }

        IDbSet<ProfileImage> ProfileImages { get; set; }

        IDbSet<CoverImage> CoverImages { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<EmbeddedGame> EmbeddedGames { get; set; } // TODO: Delete

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}

﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using SlienGames.Data.Models;

namespace SlienGames.Data.Contracts
{
    public interface ISlienGamesDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<GameProfile> GamesProfiles { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}

using System;

using SlienGames.Data.Contracts;

namespace SlienGames.Data
{
    public class SlienGamesData : ISlienGamesData, IDisposable
    {
        private readonly ISlienGamesDbContext dbContext;

        public SlienGamesData(ISlienGamesDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException($"{nameof(dbContext)} is null in unit of work!");
            }
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}

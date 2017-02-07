using SlienGames.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private SlienGamesDbContext dbContext;

        public UnitOfWork(SlienGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
